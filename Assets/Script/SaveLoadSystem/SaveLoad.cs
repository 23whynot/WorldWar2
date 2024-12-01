using System;
using UnityEngine;
using Zenject;

namespace Script.SaveLoadSystem
{
    public class SaveLoad : IInitializable

    {
        private SaveLoadManager _saveLoadManager;

        [Inject]
        public void Construct(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }

        public event Action OnLoaded;

        public int loadedData { get; private set; }


        public void SaveData(int score)
        {
            if (score >= loadedData)
            {
                GameData gameData = new GameData(score);
                _saveLoadManager.SaveGame(gameData);
            }
        }

        private void LoadData()
        {
            GameData data = _saveLoadManager.LoadGame();
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

        public void Initialize()
        {
            LoadData();
        }
    }
}