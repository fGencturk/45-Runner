using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorManager : MonoBehaviour
{
    [SerializeField] GameObject particleGO;
    ParticleSystem.MainModule particle;
    [Tooltip("For every x amount of perfect pass, change color two next two color pairs.")]
    [SerializeField] Color[] colors;
    [Tooltip("For every x amount of perfect pass, change size to next number")]
    [SerializeField] float[] sizes;

    private void Start()
    {
        particle = particleGO.GetComponent<ParticleSystem>().main;
        for (int i = 0; i < colors.Length; i++)
            colors[i].a = 1;
        particle.startColor = new ParticleSystem.MinMaxGradient(colors[0], colors[1]);
        particle.startSize = new ParticleSystem.MinMaxCurve(0f, sizes[0]);
    }

    public void ChangeParticleSettings()
    {
        if(colors.Length == 0 || sizes.Length == 0)
        {
            Debug.LogError("Arrays are not initalized!");
        }
        int perfectCount = ScoreManager.perfectCount / 5;
        int colorInd = Mathf.Min(colors.Length - 1, perfectCount * 2 + 1);
        int sizeInd = Mathf.Min(sizes.Length - 1, perfectCount);
        
        particle.startColor = new ParticleSystem.MinMaxGradient(colors[colorInd - 1], colors[colorInd]);
        particle.startSize = new ParticleSystem.MinMaxCurve(0f, sizes[sizeInd]);
    }
}
