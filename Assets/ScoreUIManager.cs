using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI multiplier;
    [SerializeField] TextMeshProUGUI endScore;

    public void UpdateScores()
    {
        score.text = ScoreManager.score.ToString();
        multiplier.text = ScoreManager.perfectCount.ToString() + "x";
    }

    public void UpdateEndScore()
    {
        endScore.text = "x" + ScoreManager.score;
    }
}
