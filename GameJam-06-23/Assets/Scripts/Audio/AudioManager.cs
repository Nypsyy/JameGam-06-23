using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;

    private static AudioManager _instance;

    private void Awake() {
        if (_instance == null)
            _instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    private void Start() {
        if (PlayerPrefs.HasKey("MainVolume")) {
            mixerGroup.audioMixer.SetFloat("MainVolume", Mathf.Log10(PlayerPrefs.GetFloat("MainVolume", 0f)) * 20);
        }
    }

    public void Play(string soundName) {
        var s = Array.Find(sounds, sound => sound.name == soundName);
        s?.source.Play();
    }

    public void Stop(string soundName) {
        var s = Array.Find(sounds, sound => sound.name == soundName);
        s?.source.Stop();
    }
}