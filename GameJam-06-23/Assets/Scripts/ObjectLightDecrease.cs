using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ObjectLightDecrease : MonoBehaviour
{
    public Light2D Light;
    // Start is called before the first frame update
    void Start()
    {   
        Light.intensity-=0.5f;
        Light.pointLightOuterRadius-=0.2f;
        Light.pointLightInnerRadius-=0.375f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}