using Script.Core;
using TMPro;
using UnityEngine;

namespace Script.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Score _score;

        private void Awake()
        {
            _score.OnScoreChanged += UpdateScore;
        }

        private void UpdateScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void OnDestroy()
        {
            _score.OnScoreChanged -= UpdateScore;
        }
    }
}
