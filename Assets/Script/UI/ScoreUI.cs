using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Script.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private GameScore _gameScore;

        [Inject]
        public void Construct(GameScore gameScore)
        {
            _gameScore = gameScore;
        }

        private void Start()
        {
            _gameScore.OnScoreChanged += UpdateGameScore;
        }

        private void UpdateGameScore(int score)
        {
            scoreText.text = score.ToString();
        }

        private void OnDestroy()
        {
            _gameScore.OnScoreChanged -= UpdateGameScore;
        }
    }
}
