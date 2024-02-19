using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavManager : MonoBehaviour
{
    public static SavManager Instance;

    public MainManager mainManager;
    private int hiScore;
    private string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHiScore();
    }


    [System.Serializable]
    class SaveData
    {
        public int playerScore;
        public string playerName1;
    }

    public void SaveHiScore()
    {
        SaveData data = new SaveData();
        data.playerScore = mainManager.m_Points;
        data.playerName1 = mainManager.playerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(UnityEngine.Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHiScore()
    {
        string path = UnityEngine.Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.playerScore;
            playerName = data.playerName1;

            mainManager.savedHiScore = hiScore;
            mainManager.savedPlayerName = playerName;

        }
    }
}
