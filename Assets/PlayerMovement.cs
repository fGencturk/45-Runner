using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    private int moveDirection = 1; //1 for right, -1 for left

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveFactor = new Vector3(speed * moveDirection * Time.deltaTime, 0);
        transform.position = transform.position + moveFactor;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMoveDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void ChangeMoveDirection()
    {
        moveDirection *= -1;
    }
    
}
