using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + new Vector3(0, -GameManager.gameSpeed * Time.deltaTime);
    }
}
