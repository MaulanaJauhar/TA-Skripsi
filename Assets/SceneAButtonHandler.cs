using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphabetButtonHandler : MonoBehaviour
{
    [SerializeField] private Button[] alphabetButtons;

    private void Start()
    {
        if (LearnSystem.instance == null) return;

        for (int i = 0; i < alphabetButtons.Length; i++)
        {
            int index = i;
            alphabetButtons[i].onClick.AddListener(() => StartCoroutine(OnButtonClick(index)));
        }
    }

    private IEnumerator OnButtonClick(int index)
    {
        // Tunggu 0.5 detik untuk animasi selesai
        yield return new WaitForSeconds(0.3f);
        LearnSystem.instance.SelectLetter(index);
    }
}