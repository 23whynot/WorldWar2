using System;
using UnityEngine;

namespace Script.Core
{
    public class GameScore : MonoBehaviour
    {
        [SerializeField] private SaveLoad saveLoad;
        [SerializeField] private Health health;
        [SerializeField] private int maxScore;

        private int count;

        private void Start()
        {
            health.OnDeath += SaveScore;
        }

        private void SaveScore()
        {
            saveLoad.SaveData(count);
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
            health.OnDeath -= SaveScore;
        }
    }
}