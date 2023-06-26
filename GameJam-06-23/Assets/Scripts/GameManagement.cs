using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject winMenuUI;
    public LevelData levelData;

    private AudioManager _audioManager;

    private int _currentBuildScenedIndex;
    private readonly WaitForSeconds _wait = new(1f);

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinMenu() {
        StartCoroutine(ShowWinMenu());
    }

    public void SceneSwitch() {
        levelData.isMusicPlaying = false;
        if (_currentBuildScenedIndex < 3) {
            SceneManager.LoadScene(_currentBuildScenedIndex + 1);
        }
    }

    public void StopCurrentTrack() {
        if (_audioManager != null) {
            _audioManager.Stop(SceneManager.GetActiveScene().name);
        }
    }

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        _currentBuildScenedIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator ShowWinMenu() {
        yield return _wait;
        winMenuUI.SetActive(true);
    }
}