using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CharacterManager.GetCharacter(DataManager.data.selectedCharacter), transform.position, Quaternion.identity);
        Destroy(this);
    }
}
