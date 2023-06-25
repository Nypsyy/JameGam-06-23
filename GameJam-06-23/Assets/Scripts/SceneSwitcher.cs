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

    public void SceneSwitch(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void NextTrack(string NextTrack){
        _audioManager.Play(NextTrack);
    }

    public void StopCurrentTrack(string CurrentTrack){
        _audioManager.Stop(CurrentTrack);               
    }
}
