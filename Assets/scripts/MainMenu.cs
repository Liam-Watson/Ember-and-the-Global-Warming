using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

// Controls all the behaviour of the buttons on the main menu
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

    // Transitions to the first cutscene
    public void NewGame()
    {
        SceneManager.LoadScene(startScene);
    }

    // Closes the game
    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }

    // Gets the users name from the InputField on the NewGame screen
    public void SetName()
    {
        username = userInput.text;
        Debug.Log(username);
    }

    // Checks whether any previous save file exists
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

    // Loads the previous save data and transitions to the saved scene
    public void LoadGame()
    {
        SaveData.LoadJson(filePath);
    }
        
}
