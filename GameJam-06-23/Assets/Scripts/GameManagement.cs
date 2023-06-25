using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject winMenuUI;

    private AudioManager _audioManager;

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        if (_audioManager != null) {
            _audioManager.Play("Level1");
        }
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinMenu() {
        StartCoroutine(ShowWinMenu());
    }

    private IEnumerator ShowWinMenu() {
        yield return new WaitForSeconds(1f);
        winMenuUI.SetActive(true);
    }
}