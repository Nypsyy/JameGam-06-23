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
        SceneManager.LoadScene("Map 1");
        _audioManager.Stop("MusicMenu");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}