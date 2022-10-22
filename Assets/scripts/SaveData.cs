using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.SceneManagement;

// Saves the current game data to a Json file, all thats stored is the scene number the player was on.
public class SaveData : MonoBehaviour
{
    public static Player player;
    public static string path;

    void Start()
    {
        player = new Player();
        path = Application.persistentDataPath + "/PlayerData.json";
    }

    public void SaveToJson()
    {
        player.level = GetSceneNumber();
        string playerData = JsonUtility.ToJson(player);
        Debug.Log(path);
        File.WriteAllText(path, playerData);
        Debug.Log("Save successful!");
    }

    public int GetSceneNumber()
    {
        int sceneNumber = 1;
        string current = SceneManager.GetActiveScene().name;

        if (string.Compare(current, "levelOne") == 0)
        {
            sceneNumber = 1;
        } 
        else if (string.Compare(current, "levelTwo") == 0)
        {
            sceneNumber = 2;
        } 
        else if (string.Compare(current, "levelThree") == 0)
        {
            sceneNumber = 3;
        }

        return sceneNumber; 
    }

    public static void LoadJson(string filePath)
    {
        string playerData = File.ReadAllText(filePath);
        player = JsonUtility.FromJson<Player>(playerData);
        SceneManager.LoadScene(player.level);
    }
}

[System.Serializable]
public class Player
{
    public int level;
    //public string name;
}
