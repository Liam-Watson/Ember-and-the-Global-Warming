using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int startScene;
    public TMP_InputField userInput;
    public Button loadButton;

    private string username;

    void Start()
    {
        SetLoadButton();
    }

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

    public void SetLoadButton()
    {
        if (SaveSystem.Exists())
        {
            Debug.Log("Exists");
            loadButton.enabled = true;
        } else 
        {
            Debug.Log("Doesn't exist");
            loadButton.enabled = false;
        }
    }
        
}
