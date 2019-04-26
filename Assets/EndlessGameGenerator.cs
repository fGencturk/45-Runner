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
        

    // Start is called before the first frame update
    void Start()
    {
        Vector3 worldLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX = worldLimit.x;
        xLimit = screenX * 0.6f;
        screenY = worldLimit.y;

        GameManager.gameSpeed = speedCurve.Evaluate(Time.time / 60f);
        Invoke("GenerateObstacle", 1);
    }


    void GenerateObstacle()
    {
        minDistanceObs = minDistanceObsCurve.Evaluate(Time.time / 60f);
        maxDistanceObs = maxDistanceObsCurve.Evaluate(Time.time / 60f);
        GameManager.gameSpeed = speedCurve.Evaluate(Time.time / 60f);

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
