using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int playerScore;
    public long timestamp;
}

[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> playerDataList = new List<PlayerData>();
}

public class DataController
{
    private static DataController _instance;
    private PlayerDataList playerDataWrapper = new PlayerDataList();

    public static DataController instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = new DataController();
            return _instance;
        }
    }

    public void SaveScore()
    {
        PlayerData currentPlayerData = new PlayerData
        {
            playerName = GameUIController.instance.playerName,
            playerScore = GameManager.instance.points,
            timestamp = DateTime.UtcNow.Ticks
        };

        playerDataWrapper.playerDataList.Add(currentPlayerData);

        string json = JsonUtility.ToJson(playerDataWrapper);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public PlayerDataList LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerDataWrapper = JsonUtility.FromJson<PlayerDataList>(json);
        }

        return playerDataWrapper;
    }

    private List<PlayerData> SortPlayerData()
    {
        return playerDataWrapper.playerDataList
            .OrderByDescending(playerData => playerData.playerScore)
            .ThenByDescending(playerData => playerData.timestamp)
            .ToList();
    }

    public PlayerData GetPlayerWithHighestScore()
    {
        if (playerDataWrapper.playerDataList.Count == 0)
        {
            return null;
        }

        List<PlayerData> sortedPlayers = SortPlayerData();

        return sortedPlayers.FirstOrDefault();
    }

    public List<PlayerData> GetTopPlayers(int count)
    {
        if (playerDataWrapper.playerDataList.Count == 0)
        {
            return new List<PlayerData>();
        }

        List<PlayerData> sortedPlayers = SortPlayerData();

        count = Mathf.Min(count, sortedPlayers.Count);

        return sortedPlayers.GetRange(0, count);
    }
}
