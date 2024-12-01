using System;
using Script.SaveLoadSystem;
using Zenject;

namespace Script.Core
{
    public class GameScore
    { 
        private SaveLoad _saveLoad;
        private int maxScore;

        private int count;
        private Health _health;

        [Inject]
        public void Construct(Health health, SaveLoad saveLoad)
        {
            _health = health;
            _saveLoad = saveLoad;
        }

        private void Start()
        {
            _health.OnDeath += SaveScore;
        }

        private void SaveScore()
        {
            _saveLoad.SaveData(count);
        }

        public event Action<int> OnScoreChanged;

        public event Action OnMaxScore;

    
        private void Awake()
        {
            OnScoreChanged?.Invoke(count);
        }

        public void Increase(int amount)
        {
            count += amount;
            OnScoreChanged?.Invoke(count);
            CheckMaxScore();
        }

        private void CheckMaxScore()
        {
            if (count >= maxScore)
            {
                OnMaxScore?.Invoke();
            }
        }

        private void OnDisable()
        {
            _health.OnDeath -= SaveScore;
        }
    }
}