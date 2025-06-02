using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<ViewManager>().PlayScene("MainMenu");
    }
}
