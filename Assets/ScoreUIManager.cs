using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text multiplier;

    public void UpdateScores()
    {
        score.text = ScoreManager.score.ToString();
        multiplier.text = ScoreManager.perfectCount.ToString() + "x";
    }
}
