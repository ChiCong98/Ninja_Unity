﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public string playerName;

    public PlayerData(PlayerInfo player)
    {
        playerName = player.playerName;
    }
}
