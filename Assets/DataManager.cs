using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static PlayerData data;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("DataManager").Length > 1)
            Destroy(this.gameObject);
        data = SaveManager.LoadPlayer();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}