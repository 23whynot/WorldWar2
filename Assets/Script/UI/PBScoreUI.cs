using TMPro;
using UnityEngine;

namespace Script.UI
{
    public class PBScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void SetCount(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
