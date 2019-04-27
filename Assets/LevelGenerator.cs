using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject nextLevel;
    [SerializeField] AnimationCurve obstacleDistanceCurve;
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] int initialObstacleCount = 10;
    [SerializeField] LevelUIManager levelUI;
    public int level = 1;

    private float screenX,
        screenY,
        xLimit;

    private float lastObstaclePosX = 0;
    private float obstacleDistance;


    void Start()
    {
        Vector3 worldLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX = worldLimit.x;
        xLimit = screenX * 0.6f;
        screenY = worldLimit.y;
        
        level = Player.data.maxLevel;

        GameManager.gameSpeed = speedCurve.Evaluate(Time.time / 60f);
        GenerateLevel();

    }

    public void NextLevel()
    {
        level++;
        Player.data.maxLevel++;
        GenerateLevel();
    }

    void GenerateLevel()
    {
        levelUI.UpdateLevel(level);

        obstacleDistance = obstacleDistanceCurve.Evaluate(level / 100f);
        GameManager.gameSpeed = speedCurve.Evaluate(level / 100f);

        int obsCount = initialObstacleCount + level;

        for (int i = 0; i < obsCount; i++)
            Invoke("CreateObstacle", (obstacleDistance / GameManager.gameSpeed) * i);
        Invoke("GenerateNextLevelObs", (obstacleDistance / GameManager.gameSpeed) * obsCount);

    }

    void GenerateNextLevelObs()
    {
        Instantiate(nextLevel, new Vector2(0, obstacleDistance + screenY * 2 + 1), Quaternion.identity);
    }

    void CreateObstacle()
    {
        int direction;
        if (lastObstaclePosX > xLimit)
            direction = -1;
        else if (lastObstaclePosX < -xLimit)
            direction = 1;
        else
            direction = Random.Range(0, 2) * 2 - 1;
        float xRandom = obstacleDistance * direction;

        float xValue = Mathf.Clamp(lastObstaclePosX + xRandom, -screenX, screenX);
        lastObstaclePosX = xValue;
        Instantiate(obstacle, new Vector2(xValue, obstacleDistance + screenY * 2 + 1), Quaternion.identity);
    }
}
