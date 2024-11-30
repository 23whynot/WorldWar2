using System;
using Script.Core;
using Script.SaveLoadSystem;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private SaveLoadManager saveLoadManager;
    
    public event Action OnLoaded;
    
    public int loadedData { get; private set; }

    private void Start()
    {
        LoadData();
    }

    public void SaveData(int score)
    {
        if (score >= loadedData)
        {
            GameData gameData = new GameData(score);
            saveLoadManager.SaveGame(gameData);
        }
    }

    private void LoadData()
    {
        GameData data = saveLoadManager.LoadGame();
        if (data == null)
        {
            Debug.Log("Нет файла");
            loadedData = 0; 
        }
        else
        {
            loadedData = data.Data; 
            Debug.Log("Данные загружены: " + loadedData);
        }
        
        OnLoaded?.Invoke();
    }
}
