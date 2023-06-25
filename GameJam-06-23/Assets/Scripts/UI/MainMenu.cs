using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioManager _audioManager;


    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        _audioManager.Play("MusicMenu");
    }

    public void LoadGame() {
        _audioManager.Play("Menu");
        _audioManager.Stop("MusicMenu");
        SceneManager.LoadScene("Map 1");
        _audioManager.Play("Level1");
    }


    public void QuitGame() {
        _audioManager.Play("Menu");
        Debug.Log("Quit");
        Application.Quit();
    }
}