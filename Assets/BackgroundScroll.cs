using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

 
    private float speed;
    private float yFactor;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed;
        yFactor = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.deltaTime * speed / yFactor);
        GetComponent<Renderer>().material.mainTextureOffset += offset;

    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
