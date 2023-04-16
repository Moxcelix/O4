using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _mainSceneIndex = 1;

    public void OpenMainScene(int sceneState)
    {
        OpenMainScene((SceneState)sceneState);
    }
    public void OpenMainScene(SceneState sceneState)
    {
        GlobalSpace.SetSceneState(sceneState);
        SceneManager.LoadScene(_mainSceneIndex);
    }
}
