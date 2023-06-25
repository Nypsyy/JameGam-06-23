using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour
{
    public LevelData levelData;
    private AudioManager _audioManager;
    void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {       
    }

    public void SceneSwitch(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        try
        {
            levelData.isMusicPlaying=false;
            SceneManager.LoadScene(currentScene + 1);
        }
        catch{}
        
    }


    public void StopCurrentTrack(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        _audioManager?.Stop("Level"+currentScene);               
    }
}
