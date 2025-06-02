using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayLetterData : MonoBehaviour
{
    public SpriteRenderer imageAbjad;
    public Text textNamaObj;
    public SpriteRenderer imageObj;

    private void Start()
    {
        if (SelectedLetterData.SelectedData != null)
        {

            // Isi data UI
            imageAbjad.sprite = SelectedLetterData.SelectedData.Gambar_Abjad;
            textNamaObj.text = SelectedLetterData.SelectedData.Nama;
            imageObj.sprite = SelectedLetterData.SelectedData.Gambar_Obj;
        }
        else
        {
            Debug.LogError("Data tidak tersedia!");
        }
    }
    
    public void KembaliKeSceneMenu()
    {
        SelectedLetterData.SelectedData = null; // Reset data
        SceneManager.LoadScene("Testing"); // Kembali ke scene menu
    }
}
