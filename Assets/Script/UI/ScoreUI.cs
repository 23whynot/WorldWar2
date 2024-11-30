using Script.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameScore gameScore;

        private void Awake()
        {
            gameScore.OnScoreChanged += UpdateGameScore;
        }

        private void UpdateGameScore(int score)
        {
            scoreText.text = score.ToString();
        }

        private void OnDestroy()
        {
            gameScore.OnScoreChanged -= UpdateGameScore;
        }
    }
}
