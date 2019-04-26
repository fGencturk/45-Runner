using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] float minDistanceObs = 3f;
    [SerializeField] float maxDistanceObs = 3f;
    [SerializeField] float initialSpeed = 3f;
    public AnimationCurve curve;
    private float lastObstaclePosX;

    [SerializeField] PlayerMovement player;
    [SerializeField] BackgroundScroll background;

    private float distanceDecreaseFactor;

    public static float speed;
    private float screenX,
        screenY,
        xLimit;

    // Start is called before the first frame update
    void Start()
    {
        distanceDecreaseFactor = 0.3f;
        SetSpeed(initialSpeed);
        Vector3 worldLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX = worldLimit.x;
        xLimit = screenX * 0.6f;
        screenY = worldLimit.y;


        EndlessGame();
        Invoke("GenerateObstacle", 1);
    }

    // Update is called once per frame
    void Update()
    {
    }


    void GenerateObstacle()
    {
        float yRandom = Random.Range(minDistanceObs, maxDistanceObs);
        float xRandom;
        int direction;
        if (lastObstaclePosX > xLimit)
            direction = -1;
        else if (lastObstaclePosX < -xLimit)
            direction = 1;
        else
            direction = Random.Range(0, 2) * 2 - 1;
        //xRandom = Mathf.Pow(Random.Range(0, Mathf.Pow(yRandom, edgeLuckMultiplier)), 1.0f / edgeLuckMultiplier) * direction;
        xRandom = yRandom * direction;

        float xValue = Mathf.Clamp(lastObstaclePosX + xRandom, -screenX, screenX);
        lastObstaclePosX = xValue;
        Instantiate(obstacle, new Vector2(xValue, yRandom + screenY * 2 + 1), Quaternion.identity);

        Invoke("GenerateObstacle", yRandom / speed);        
    }


    public void SetSpeed(float s)
    {
        speed = s;
        player.SetSpeed(s);
        background.SetSpeed(s);
    }



    void EndlessGame()
    {
        Invoke("DecreaseSpeed", 10f);
        Invoke("DecreaseMinDistanceObs", 10f);
        Invoke("DecreaseMaxDistanceObs", 60f);

    }

    void DecreaseSpeed()
    {
        if (speed + 0.1f >= 4.5f)
        {
            speed = 4.5f;
            return;
        }
        SetSpeed(speed + 0.1f);
        Invoke("DecreaseSpeed", 10f);
    }

    void DecreaseMinDistanceObs()
    {
        if (minDistanceObs - distanceDecreaseFactor <= 0.5f)
        {
            minDistanceObs = 0.5f;
            return;
        }
        minDistanceObs = minDistanceObs - distanceDecreaseFactor;
        Invoke("DecreaseMinDistanceObs", 10f);
    }

    void DecreaseMaxDistanceObs()
    {
        if (maxDistanceObs - distanceDecreaseFactor <= 1.5f)
        {
            maxDistanceObs = 1.5f;
            return;
        }
        maxDistanceObs = maxDistanceObs - distanceDecreaseFactor;
        Invoke("DecreaseMaxDistanceObs", 10f);
    }


}
