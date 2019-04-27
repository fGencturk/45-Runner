using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI level;

    private void Start()
    {
        gold.text = "x" + Player.data.gold;
        level.text = "LEVEL " + Player.data.maxLevel;
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("EndlessGame");
    }


    public void PlayLevel()
    {
        SceneManager.LoadScene("LevelBasedGame");
    }

}
