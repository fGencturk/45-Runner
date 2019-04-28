using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelGenerator : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LevelGenerator levelGen = GameObject.FindGameObjectWithTag("ObstacleGenerator").GetComponent<LevelGenerator>();
        levelGen.NextLevel();
    }
}
