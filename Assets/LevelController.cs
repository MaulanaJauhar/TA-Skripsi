using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [System.Serializable]
    public class DataGame
    {
        public string Nama;
        public Sprite Gambar_Obj;
    }

    [Header("Data Soal")]
    public DataGame[] dataGame;

    [Header("UI")]
    public Text hintText;
    public Button[] pilihanButtons; // Jumlah tombol disesuaikan per scene

    [Header("Game Info")]
    private int jumlahSoal;
    private int soalKe = 0;
    private int jawabanBenarID;
    public Text teksWaktu;
    public Text teksSkor;
    public RectTransform darahBar;

    private List<int> soalTersedia = new List<int>();

    void Start()
    {
        jumlahSoal = pilihanButtons.Length - 1; // Misal: 2 tombol => 1 soal

        for (int i = 0; i < dataGame.Length; i++)
            soalTersedia.Add(i);

        NextSoal();
    }
    private float s;

    void Update()
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

        if (Data.DataWaktu <= 0 || Data.DataDarah <= 0)
        {
            SceneManager.LoadScene("GameClear");
        }

        if (teksWaktu != null)
        {
            int menit = Mathf.FloorToInt(Data.DataWaktu / 60);
            int detik = Mathf.FloorToInt(Data.DataWaktu % 60);
            teksWaktu.text = $"{menit:00}:{detik:00}";
        }

        if (teksSkor != null)
            teksSkor.text = Data.DataSkor.ToString();

        if (darahBar != null)
            darahBar.sizeDelta = new Vector2(36f * Data.DataDarah, 31f);
    }


    void NextSoal()
    {
        if (soalKe >= jumlahSoal || soalTersedia.Count == 0)
        {
            LanjutLevel();
            return;
        }

        int indexSoal = soalTersedia[Random.Range(0, soalTersedia.Count)];
        soalTersedia.Remove(indexSoal);
        jawabanBenarID = indexSoal;
        hintText.text = dataGame[jawabanBenarID].Nama;

        // Acak posisi jawaban benar
        List<int> posisi = new List<int>();
        for (int i = 0; i < pilihanButtons.Length; i++) posisi.Add(i);

        int posisiBenar = posisi[Random.Range(0, posisi.Count)];
        posisi.Remove(posisiBenar);

        pilihanButtons[posisiBenar].image.sprite = dataGame[jawabanBenarID].Gambar_Obj;
        SetButtonListener(pilihanButtons[posisiBenar], true);

        // Siapkan opsi salah
        List<int> opsiSalah = new List<int>();
        for (int i = 0; i < dataGame.Length; i++)
        {
            if (i != jawabanBenarID) opsiSalah.Add(i);
        }

        for (int i = 0; i < pilihanButtons.Length; i++)
        {
            if (i == posisiBenar) continue;

            int idxSalah = opsiSalah[Random.Range(0, opsiSalah.Count)];
            opsiSalah.Remove(idxSalah);

            pilihanButtons[i].image.sprite = dataGame[idxSalah].Gambar_Obj;
            SetButtonListener(pilihanButtons[i], false);
        }

        soalKe++;
    }

    void SetButtonListener(Button btn, bool isBenar)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            if (isBenar)
            {
                Data.DataSkor += 100;
                NextSoal();
            }
            else
            {
                Data.DataDarah--;
                if (Data.DataDarah <= 0)
                {
                    SceneManager.LoadScene("GameClear");
                }
            }
        });
    }

    void LanjutLevel()
    {
        Data.DataLevel++;
        string nextScene = "Game" + Data.DataLevel;

        if (Application.CanStreamedLevelBeLoaded(nextScene))
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene("GameClear");
    }

}
