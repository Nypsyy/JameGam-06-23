using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoad : MonoBehaviour
{
    public LevelData levelData;
    private AudioManager _audioManager;

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        if (_audioManager == null || levelData.isMusicPlaying)
            return;

        _audioManager.Play(SceneManager.GetActiveScene().name);
        levelData.isMusicPlaying = true;
    }
}