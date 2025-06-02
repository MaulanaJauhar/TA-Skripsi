using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public Text TeksScore, TeksTotalScore;

    public void Start()
    {
        if (Data.DataSkor >= PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", Data.DataSkor);
        }
        TeksScore.text = Data.DataSkor.ToString();
        TeksTotalScore.text = PlayerPrefs.GetInt("Score").ToString();
    }

}
