using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public int level;
    public string playerName;
    
    public PlayerData(Player player)
    {
        level = player.level;
        name = player.name;
    }
}
