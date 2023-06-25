using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager AudioManager;
    private void Awake(){
        AudioManager= Object.FindObjectOfType<AudioManager>();
    }
    
    private void Start(){
        AudioManager.Play("MusicMenu");
    }

    public void LoadGame() {
        SceneManager.LoadScene("Map 1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
