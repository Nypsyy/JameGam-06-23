using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoad : MonoBehaviour
{
    public LevelData levelData;
    private AudioManager _audioManager;
    void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (_audioManager!=null&&!levelData.isMusicPlaying){
            _audioManager.Play("Level"+buildIndex);
            levelData.isMusicPlaying=true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
