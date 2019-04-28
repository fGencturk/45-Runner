using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveManager
{
    public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

        bf.Serialize(stream, player);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        if(!File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            return new PlayerData(0, 0, 1);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

        PlayerData data = bf.Deserialize(stream) as PlayerData;
        stream.Close();
        return data;
    }
}


[Serializable]
public class PlayerData
{
    public int gold;
    public int maxScore;
    public int maxLevel;
    public int selectedCharacter = 0;
    public LinkedList<int> ownedCharacters = new LinkedList<int>();

    public PlayerData(int gold, int maxScore, int maxLevel)
    {
        this.gold = gold;
        this.maxScore = maxScore;
        this.maxLevel = maxLevel;
    }
}
