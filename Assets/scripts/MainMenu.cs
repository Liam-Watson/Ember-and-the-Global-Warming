using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int startScene;

    public void NewGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }
}
