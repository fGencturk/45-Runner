using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static float gameSpeed = 3;
    [SerializeField] GameObject gameOverUI;
    GameObject obstacleGenerator;

    private void Start()
    {
        obstacleGenerator = GameObject.FindGameObjectWithTag("ObstacleGenerator");
    }

    public void EndGame()
    {
        DataManager.data.gold += ScoreManager.score;
        DataManager.data.maxScore = Mathf.Max(DataManager.data.maxScore, ScoreManager.score);
        SaveManager.SavePlayer(DataManager.data);
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
        EndlessGameGenerator gameGen = obstacleGenerator.GetComponent<EndlessGameGenerator>();
        if (gameGen)
            gameGen.Reset();
        ScoreManager.Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        ScoreManager.Reset();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

}
