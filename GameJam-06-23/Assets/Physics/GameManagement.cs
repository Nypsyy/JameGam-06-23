using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{

    private AudioManager AudioManager;

    private void Awake(){
        AudioManager= Object.FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Play("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
