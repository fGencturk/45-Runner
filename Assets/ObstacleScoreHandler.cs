using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScoreHandler : MonoBehaviour
{
    [SerializeField] float perfectThreshold = 0.33f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ScoreManager.GetScore(collision.transform.position.x - this.transform.position.x < perfectThreshold);
        ScoreManager.GetScore(true);
        Destroy(gameObject);
    }
}
