using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneController.Instance.LoadScene("MainMenu");
    }
}
