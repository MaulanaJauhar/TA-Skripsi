using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayLetterData : MonoBehaviour
{
    public SpriteRenderer imageAbjad;
    public Text textNamaObj;
    public SpriteRenderer imageObj;
    public Button btnNext;

    private void Start()
    {
        if (SelectedLetterData.SelectedData != null)
        {

            // Isi data UI
            imageAbjad.sprite = SelectedLetterData.SelectedData.Gambar_Abjad;
            textNamaObj.text = SelectedLetterData.SelectedData.Nama;
            imageObj.sprite = SelectedLetterData.SelectedData.Gambar_Obj;

            btnNext.onClick.AddListener(MoveToNextScene);
        }
        else
        {
            Debug.LogError("Data tidak tersedia!");
        }
    }
    private void MoveToNextScene()
    {
        // Pastikan data abjad tetap ada ketika berpindah ke scene berikutnya
        if (SelectedLetterData.SelectedData != null)
        {
            SceneManager.LoadScene("Belajar1"); // Mengarahkan ke scene Belajar1
        }
        else
        {
            Debug.LogError("Data abjad tidak tersedia untuk melanjutkan!");
        }
    }
    
    public void KembaliKeSceneMenu()
    {
        SelectedLetterData.SelectedData = null; // Reset data
        SceneManager.LoadScene("MenuHuruf"); // Kembali ke scene menu
    }
}
