using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Data
{
    public static int DataLevel, DataWaktu, DataSkor, DataDarah;   
}
public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    int MaxLevel = 10;

    [Header("Setting Game")]
    public bool GameAktif;
    public bool GameSelesai;
    public bool SistemAcak;
    public int Target_Obj, DataSekarang;
    // public int DataLevel, DataWaktu, DataSkor, DataDarah; 
    

    [Header("UI Game")]
    public Text Teks_Level;
    public Text Teks_Waktu, Teks_Skor;
    public RectTransform Darah;

    [Header("Obj GUI")]
    public GameObject Gui_Pause;
    public GameObject Gui_Transisi;

    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar_Obj;
    }
    [Header("Setting Standard")]
    public DataGame[] Data_Game;

    [Space]
    [Space]
    [Space]


    public Obj_TempatDrop[] Drop_Tempat;
    public Obj_Drag[] Drag_Obj;


    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameAktif = false;
        GameSelesai = false;
        ResetData();
        Target_Obj = Drop_Tempat.Length;
        if (SistemAcak)
            AcakSoal();
        DataSekarang = 0;
        GameAktif = true;
    }

    void ResetData()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game0")
        {
            Data.DataWaktu = 60 * 3; // 3 menit
            Data.DataSkor = 0;
            Data.DataDarah = 5;
            Data.DataLevel = 0;
        }

    }

    float s;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AcakSoal();
        }
        if (GameAktif && !GameSelesai)
        {
            if (Data.DataWaktu > 0)
            {
                s += Time.deltaTime;
                if (s >= 1)
                {
                    Data.DataWaktu--;
                    s = 0;
                }
            }
            if (Data.DataWaktu <= 0)
            {
                GameAktif = false;
                GameSelesai = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");

                // GameOver
            }

            if (Data.DataDarah <= 0)
            {
                GameAktif = false;
                GameSelesai = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");

                // GameOver   
            }
            if (DataSekarang >= Target_Obj)
            {
                GameSelesai = true;
                GameAktif = false;
                // GameClear
                if (Data.DataLevel < (MaxLevel - 1))
                {
                    Data.DataLevel++;
                    // Pindah ke level selanjutnya
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game" + Data.DataLevel);
                    // Gui_Transisi.GetComponent<UI_Control>().Btn_Pindah("Game" + Data.DataLevel);
                }
                else
                {
                    
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");
                    // Pindah ke menu selesai
                }
            }
        }
        SetUI();
    }

    public List<int> _AcakSoal = new List<int>();
    public List<int> _AcakPosisi = new List<int>();
    int rand;
    int rand2;
    public void AcakSoal()
    {
        _AcakSoal.Clear();
        _AcakPosisi.Clear();

        _AcakSoal = new List<int>(new int[Drag_Obj.Length]);
        for (int i = 0; i < _AcakSoal.Count; i++)
        {
            rand = Random.Range(1, Data_Game.Length);
            while (_AcakSoal.Contains(rand))
                rand = Random.Range(1, Data_Game.Length);
            _AcakSoal[i] = rand;

            Drag_Obj[i].ID = rand - 1;
            Drag_Obj[i].Teks.text = Data_Game[rand - 1].Nama;
        }

        _AcakPosisi = new List<int>(new int[Drop_Tempat.Length]);

        for (int i = 0; i < _AcakPosisi.Count; i++)
        {
            rand2 = Random.Range(1, _AcakSoal.Count + 1);
            while (_AcakPosisi.Contains(rand2))
                rand2 = Random.Range(1, _AcakSoal.Count + 1);
            _AcakPosisi[i] = rand2;

            Drop_Tempat[i].Drop.ID = _AcakSoal[rand2 - 1] - 1;
            Drop_Tempat[i].Gambar.sprite = Data_Game[Drop_Tempat[i].Drop.ID].Gambar_Obj;
        }
    }

    public void SetUI()
    {
        Teks_Level.text = (Data.DataLevel + 1).ToString();

        int Menit = Mathf.FloorToInt(Data.DataWaktu / 60);
        int Detik = Mathf.FloorToInt(Data.DataWaktu % 60);
        Teks_Waktu.text = Menit.ToString("00") + ":" + Detik.ToString("00");

        Teks_Skor.text = Data.DataSkor.ToString();

        Darah.sizeDelta = new Vector2(36f * Data.DataDarah, 31f);
    }

    public void Btn_Pause(bool Pause)
    {
        if (Pause)
        {
            GameAktif = false;
            Gui_Pause.SetActive(true);
        }
        else
        {
            GameAktif = true;
            Gui_Pause.SetActive(false);
        }
    }
}