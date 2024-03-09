using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneController.Instance.LoadScene("Gameplay");
    }

    public void OpenSettings()
    {
        SceneController.Instance.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
