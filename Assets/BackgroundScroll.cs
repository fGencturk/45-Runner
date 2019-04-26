using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    
    private float yFactor;
    // Start is called before the first frame update
    void Start()
    {
        yFactor = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.deltaTime * GameManager.gameSpeed / yFactor);
        GetComponent<Renderer>().material.mainTextureOffset += offset;

    }
    
}
