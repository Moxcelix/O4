using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private int _backSceneIndex = 0;
    public void Back()
    {
        SceneManager.LoadScene(_backSceneIndex);
    }
}
