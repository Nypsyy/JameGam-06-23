using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer mixer;

    private Slider _slider;
    private const string VolumePref = "MainVolume";

    private void Awake() {
        _slider = GetComponent<Slider>();
    }

    private void Start() {
        if (PlayerPrefs.HasKey(VolumePref)) {
            _slider.value = PlayerPrefs.GetFloat(VolumePref, 1f);
        }
    }

    public void SetMainLevel(float sliderValue) {
        var dbValue = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("MainVolume", dbValue);

        PlayerPrefs.SetFloat(VolumePref, sliderValue);
        PlayerPrefs.Save();
    }
}