using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HaricotLightDecrease : MonoBehaviour
{
    public Light2D Light;

    private void Start() {
        Light.intensity -= 0.25f;
        Light.pointLightOuterRadius -= 0.2f;
        Light.pointLightInnerRadius -= 0.75f;
    }
}