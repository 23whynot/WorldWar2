using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PBScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetCount(int score)
    {
        scoreText.text = score.ToString();
    }
}
