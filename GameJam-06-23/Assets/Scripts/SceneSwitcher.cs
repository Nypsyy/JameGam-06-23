using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour
{

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
            
            SceneManager.LoadScene(currentScene + 1);
        }
        catch{}
        
    }

    public void NextTrack()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        _audioManager?.Play("Level"+ currentScene);
    }

    public void StopCurrentTrack(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        _audioManager?.Stop("Level"+currentScene);               
    }
}
