using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public int buttonIndex;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        
        // Pastikan LearnSystem.instance sudah ada
        if (LearnSystem.instance != null)
        {
            _button.onClick.AddListener(() => LearnSystem.instance.SelectLetter(buttonIndex));
        }
        else
        {
            Debug.LogError("LearnSystem instance tidak ditemukan!");
        }
    }
}