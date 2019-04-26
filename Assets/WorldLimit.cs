using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    PlayerMovement player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = collision.transform.gameObject.GetComponent<PlayerMovement>();
            player.canMove = false;
            player.ChangeMoveDirection();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.canMove = true;
        }
    }
}
