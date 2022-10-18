using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int startScene;
    public TMP_InputField userInput;
    private string username;

    public void NewGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }

    public void SetName()
    {
        username = userInput.text;
        Debug.Log(username);
    }
        
}
