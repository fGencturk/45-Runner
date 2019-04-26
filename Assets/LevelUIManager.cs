﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] Text level;
    [SerializeField] float effectDuration = 2f;

    private float startTime;
    private float maxScale = 2;
    public void UpdateLevel(int i)
    {
        level.text = "Level " + i;
        StartCoroutine(UIEffect());
    }

    IEnumerator UIEffect()
    {
        Transform levelObj = level.gameObject.transform;
        startTime = Time.time;

        Vector3 initialScale = levelObj.localScale;
        float halfEffect = effectDuration / 2;
        float timeLeft = startTime + halfEffect - Time.time;
        while (timeLeft > 0)
        {
            float factor = (halfEffect - timeLeft) *  maxScale;
            levelObj.localScale = initialScale + new Vector3(factor, factor, factor);
            yield return new WaitForEndOfFrame();
            timeLeft = startTime + effectDuration / 2 - Time.time;
        }
        timeLeft = startTime + effectDuration - Time.time;

        while (timeLeft > 0)
        {
            float factor = timeLeft *  maxScale;
            levelObj.localScale = initialScale + new Vector3(factor, factor, factor);
            yield return new WaitForEndOfFrame();
            timeLeft = startTime + effectDuration - Time.time;
        }
        yield return null;
    }
}
