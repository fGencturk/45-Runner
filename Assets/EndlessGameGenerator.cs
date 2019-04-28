using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGameGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] AnimationCurve minDistanceObsCurve;
    [SerializeField] AnimationCurve maxDistanceObsCurve;
    [SerializeField] AnimationCurve speedCurve;


    private float screenX,
        screenY,
        xLimit;

    private float lastObstaclePosX = 0;
    private float minDistanceObs,
        maxDistanceObs;

    private float startTime;
        

    // Start is called before the first frame update
    void Start()
    {
        Vector3 worldLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX = worldLimit.x;
        xLimit = screenX * 0.6f;
        screenY = worldLimit.y;

        Reset();
        Invoke("GenerateObstacle", 1);
    }

    public void Reset()
    {

        startTime = Time.time;
        GameManager.gameSpeed = speedCurve.Evaluate((Time.time - startTime) / 60f);
    }

    void GenerateObstacle()
    {
        minDistanceObs = minDistanceObsCurve.Evaluate((Time.time - startTime) / 60f);
        maxDistanceObs = maxDistanceObsCurve.Evaluate((Time.time - startTime) / 60f);
        GameManager.gameSpeed = speedCurve.Evaluate((Time.time - startTime) / 60f);

        float yRandom = Random.Range(minDistanceObs, maxDistanceObs);
        float xRandom;
        int direction;
        if (lastObstaclePosX > xLimit)
            direction = -1;
        else if (lastObstaclePosX < -xLimit)
            direction = 1;
        else
            direction = Random.Range(0, 2) * 2 - 1;
        xRandom = yRandom * direction;

        float xValue = Mathf.Clamp(lastObstaclePosX + xRandom, -screenX, screenX);
        lastObstaclePosX = xValue;
        Instantiate(obstacle, new Vector2(xValue, yRandom + screenY * 2 + 1), Quaternion.identity);

        Invoke("GenerateObstacle", yRandom / GameManager.gameSpeed);        
    }

}
