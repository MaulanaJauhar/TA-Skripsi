using UnityEngine;
using System;
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
        public string[] Kombinasi;  // Menambahkan array kombinasi untuk setiap abjad
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
        InitKombinasi();
    }

    private void InitKombinasi()
    {
        // Daftar vokal
        char[] vokal = new char[] { 'A', 'E', 'I', 'O', 'U' };

        // Inisialisasi kombinasi untuk huruf vokal (index 0-4)
        for (int i = 0; i < vokal.Length; i++)
        {
            char huruf = vokal[i];
            int index = i; // Index akan mulai dari 0 hingga 4 untuk vokal
            Data_Abjad[index].Kombinasi = new string[]
            {
                $"{huruf}a - {huruf}a", $"{huruf}i - {huruf}i", $"{huruf}u - {huruf}u", $"{huruf}e - {huruf}e", $"{huruf}o - {huruf}o"
            };
        }

        // Inisialisasi kombinasi untuk huruf konsonan (index 5-25)
        int konsonanIndex = 5; // Dimulai dari index 5
        for (char huruf = 'B'; huruf <= 'Z'; huruf++)
        {
            if (Array.IndexOf(vokal, huruf) == -1) // Menghindari huruf vokal
            {
                Data_Abjad[konsonanIndex].Kombinasi = new string[]
                {
                    $"{huruf}a - {huruf}a", $"{huruf}i - {huruf}i", $"{huruf}u - {huruf}u", $"{huruf}e - {huruf}e", $"{huruf}o - {huruf}o"
                };
                konsonanIndex++;
            }
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuBelajar");
    }
}
