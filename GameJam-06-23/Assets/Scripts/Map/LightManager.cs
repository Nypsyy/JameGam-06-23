using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D globalLight;
    public float deltaIntensity = .1f;
    public Light2D playerLight;
    public float playerDeltaIntensity = .25f;
    public float playerDeltaInnerRadius = .2f;
    public float playerDeltaOuterRadius = .75f;

    public void LightUpMap() {
        StartCoroutine(IncreaseLightIntensity());
    }

    public void DecreasePlayerLight() {
        playerLight.intensity -= playerDeltaIntensity;
        playerLight.pointLightOuterRadius -= playerDeltaInnerRadius;
        playerLight.pointLightInnerRadius -= playerDeltaOuterRadius;
    }

    private IEnumerator IncreaseLightIntensity() {
        while (globalLight.intensity < 1f) {
            globalLight.intensity += deltaIntensity;
            yield return null;
        }
    }
}