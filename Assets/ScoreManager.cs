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


    public static void GetScore(bool isPerfect)
    {
        int s = 1;
        if (isPerfect)
        {
            s = 2;
            perfectCount++;
        }
        else
        {
            perfectCount = 1;
        }
        score += s * perfectCount;
        scoreUI.UpdateScores();
        GameObject.FindGameObjectWithTag("Player").GetComponent<ParticleColorManager>().ChangeParticleSettings();
    }

}
