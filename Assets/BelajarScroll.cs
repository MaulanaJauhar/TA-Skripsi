using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BelajarScroll : MonoBehaviour
{
    public Text textPanel1;
    public Text textPanel2;
    public Text textPanel3;
    public Text textPanel4;
    public Text textPanel5;

    private void Start()
    {
        if (SelectedLetterData.SelectedData != null)
        {
            // Update teks panel sesuai dengan abjad yang dipilih
            UpdateTextPanels(SelectedLetterData.SelectedData);
        }
        else
        {
            Debug.LogError("Data tidak tersedia!");
        }
    }

    private void UpdateTextPanels(LearnSystem.DataAbjad selectedData)
    {
        // Memeriksa apakah Kombinasi tersedia untuk data abjad yang dipilih
        if (selectedData.Kombinasi != null && selectedData.Kombinasi.Length >= 5)
        {
            // Menampilkan kombinasi pada setiap panel
            textPanel1.text = selectedData.Kombinasi[0];
            textPanel2.text = selectedData.Kombinasi[1];
            textPanel3.text = selectedData.Kombinasi[2];
            textPanel4.text = selectedData.Kombinasi[3];
            textPanel5.text = selectedData.Kombinasi[4];
        }
        else
        {
            Debug.LogError("Kombinasi abjad tidak tersedia atau kurang dari 5!");
        }
    }
}
