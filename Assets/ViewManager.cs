using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewManager : MonoBehaviour
{
    public void PlayScene(string nameScene)
    {
        SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
    }
    
    public void UnloadScene(string nameScene)
    {
        SceneManager.UnloadSceneAsync(nameScene);
    }
}
