using System;
using System.IO;
using Script;
using Script.SaveLoadSystem;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string savePath;

    
    private void Awake()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    public void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to " + savePath);
    }

    public GameData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded from " + savePath);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
        
        
    }
}

