using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ScoreManager.GetScore(collision.transform.position.x - this.transform.position.x < perfectThreshold);
        ScoreManager.GetScore();
        Destroy(this.transform.parent.gameObject);
    }
}
