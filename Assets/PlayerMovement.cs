using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int moveDirection = 1; //1 for right, -1 for left
    public bool canMove = true;

    [SerializeField] Transform particle;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = particle.transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, -45 * moveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveFactor = new Vector3(GameManager.gameSpeed * moveDirection * Time.deltaTime, 0);
        transform.position = transform.position + moveFactor;

        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            ChangeMoveDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EndGame();
            Destroy(this.gameObject);

        }
    }

    public void ChangeMoveDirection()
    {
        moveDirection *= -1;
        transform.rotation = Quaternion.Euler(0, 0, -45 * moveDirection);
        particle.rotation = initialRotation;
    }

}
