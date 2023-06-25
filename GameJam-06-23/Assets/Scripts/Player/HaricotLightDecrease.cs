using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HaricotLightDecrease : MonoBehaviour
{
    public Light2D Light;
    // Start is called before the first frame update
    void Start()
    {
        Light.intensity-=0.25f;
        Light.pointLightOuterRadius-=0.2f;
        Light.pointLightInnerRadius-=0.75f;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
