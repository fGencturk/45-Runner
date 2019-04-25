using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    //the multipler that makes the next obstacle created at edges
    [SerializeField] int edgeLuckMultiplier = 2;
    [SerializeField] GameObject obstacle;
    [SerializeField] float minDistanceObs = 2f;
    [SerializeField] float maxDistanceObs = 5f;
    private float lastObstaclePosX;
    public static float speed;
    private float screenX,
        screenY,
        xLimit;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed;
        Invoke("GenerateObstacle", 1);
        Vector3 worldLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX = worldLimit.x;
        xLimit = screenX * 0.6f;
        screenY = worldLimit.y;
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
        xRandom = Mathf.Pow(Random.Range(0, Mathf.Pow(yRandom, edgeLuckMultiplier)), 1.0f / edgeLuckMultiplier) * direction;

        float xValue = Mathf.Clamp(lastObstaclePosX + xRandom, -screenX, screenX);
        lastObstaclePosX = xValue;
        Instantiate(obstacle, new Vector2(xValue, yRandom + screenY * 2 + 1), Quaternion.identity);

        Invoke("GenerateObstacle", yRandom / speed);
        
    }


    public static void SetSpeed(float s)
    {
        speed = s;
    }
}
