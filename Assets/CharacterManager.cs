using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    private static GameObject[] chrs;

    private void Start()
    {
        chrs = characters;
    }
    public static GameObject GetCharacter(int i)
    {
        return chrs[i];
    }


}
