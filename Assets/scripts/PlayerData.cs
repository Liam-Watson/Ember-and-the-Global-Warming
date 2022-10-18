using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int level;
    
    public PlayerData(Player player)
    {
        level = player.level;
    }
}
