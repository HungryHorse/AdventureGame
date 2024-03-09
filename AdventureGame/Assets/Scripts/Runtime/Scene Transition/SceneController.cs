using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance => instance;

    [SerializeField]
    private string startScene;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;

        if (!string.IsNullOrEmpty(startScene))
            LoadScene(startScene);
        else
            LoadScene(1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public AsyncOperation LoadSceneAsync(string sceneName)
    {
        return SceneManager.LoadSceneAsync(sceneName);
    }

    public AsyncOperation LoadSceneAsync(int sceneIndex)
    {
        return SceneManager.LoadSceneAsync(sceneIndex);
    }
}
