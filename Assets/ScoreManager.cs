using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int perfectCount = 0;
    private static ScoreUIManager scoreUI;
    private static ParticleColorManager particle;

    private void Start()
    {
        scoreUI = GameObject.FindGameObjectWithTag("ScoreUIManager").GetComponent<ScoreUIManager>();
        particle = GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleColorManager>();
    }


    public static void GetScore()
    {
        score += perfectCount;
        perfectCount++;
        scoreUI.UpdateScores();
    }

    public static void ResetMultiplier()
    {
        perfectCount = 1;
        scoreUI.UpdateScores();
    }

    public static void Reset()
    {
        score = 0;
        perfectCount = 1;
        scoreUI.UpdateScores();
    }

    public static void UpdateEndScreen()
    {
        scoreUI.UpdateEndScore();
    }
}
