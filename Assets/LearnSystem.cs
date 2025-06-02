using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LearnSystem : MonoBehaviour
{
    public static LearnSystem instance;

    [System.Serializable]
    public class DataAbjad
    {
        public string Nama;
        public Sprite Gambar_Obj;
        public Sprite Gambar_Abjad;
    }

    public DataAbjad[] Data_Abjad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Tetap ada di semua scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

public void SelectLetter(int index)
    {
        StartCoroutine(SelectLetterWithDelay(index));
    }

    private IEnumerator SelectLetterWithDelay(int index)
    {
        Debug.Log($"Memilih abjad index: {index}");
        
        // Tunggu selama 0.5 detik untuk memberi waktu animasi tombol
        yield return new WaitForSeconds(0.3f);
        
        if (index >= 0 && index < Data_Abjad.Length)
        {
            SelectedLetterData.SelectedData = Data_Abjad[index];
            SceneManager.LoadScene("Belajar0");
        }
        else
        {
            Debug.LogWarning("Index out of range: " + index);
        }
    }
    public void Btn_Back()
    {
        // Kembali ke scene sebelumnya
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuHuruf");
    }
}
