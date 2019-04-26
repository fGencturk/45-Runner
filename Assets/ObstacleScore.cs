using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScore : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        ScoreManager.ResetMultiplier();
    }
}
