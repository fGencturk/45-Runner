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
        gold.text = "x" + DataManager.data.gold;
        level.text = "LEVEL " + DataManager.data.maxLevel;
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
