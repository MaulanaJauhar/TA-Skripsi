using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{

    public bool IsTransisi, IsNoTransisi;
    string SaveNamaScene;

    private void Awake()
    {
        if (IsTransisi && IsNoTransisi)
        {
            gameObject.SetActive(false);
        }
    }
    public void Btn_Suara(int id)
    {

    }

    public void Btn_Pindah(String nama)
    {
        this.gameObject.SetActive(true);
        SaveNamaScene = nama;
        GetComponent<Animator>().Play("end");
    }

    public void Btn_Restart()
    {
        SaveNamaScene = SceneManager.GetActiveScene().name;
        GetComponent<Animator>().Play("end");
    }

    public void Pindah()
    {
        SceneManager.LoadScene(SaveNamaScene);
    }
}
