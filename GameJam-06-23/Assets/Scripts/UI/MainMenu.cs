using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioManager _audioManager;
    public Animator animator;


    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        _audioManager.Play("Level0");
    }

    public void LoadGame() {
        _audioManager.Play("Menu");
        StartCoroutine(LoadNextScene(_audioManager,animator));

    }
    
    
    private static IEnumerator LoadNextScene(AudioManager _audioManager,  Animator animator) {
        animator.SetBool("IsPlay", true);
        yield return new WaitForSeconds(1.45f);
        _audioManager.Play("Level1");
        SceneManager.LoadScene("Map 1");
    }

    public void QuitGame() {
        _audioManager.Play("Menu");
        Debug.Log("Quit");
        Application.Quit();
    }
}