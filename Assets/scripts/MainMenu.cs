using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int startScene;
    public TMP_InputField userInput;
    public Button loadButton;
    private string filePath;

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
        filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            Debug.Log("Exists");
            loadButton.enabled = true;
        } else 
        {
            Debug.Log("Doesn't exist");
            loadButton.enabled = false;
        }
    }

    public void LoadGame()
    {
        SaveData.LoadJson(filePath);
    }
        
}
