using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static float gameSpeed;
    [SerializeField] GameObject gameOverUI;


    public void EndGame()
    {
        Player.data.gold += ScoreManager.score;
        Player.data.maxScore = Mathf.Max(Player.data.maxScore, ScoreManager.score);
        SaveManager.SavePlayer(Player.data);
        StartCoroutine(SlowTime());
    }

    IEnumerator SlowTime()
    {
        float startTime = Time.time;
        while(startTime + .4f > Time.time)
        {
            Time.timeScale = 1f - (Time.time - startTime) * 2;
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = 0.0001f;
        LoadGameOverUI();
        yield return null;

    }

    void LoadGameOverUI()
    {
        ScoreManager.UpdateEndScreen();
        gameOverUI.SetActive(true);
    }


    public void LoadThisScene()
    {
        ScoreManager.Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

}
