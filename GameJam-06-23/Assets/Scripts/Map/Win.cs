using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public UnityEvent onWinEvent;

    private const string CompletedPref = "Completed";

    private void Awake() {
        onWinEvent ??= new UnityEvent();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            onWinEvent.Invoke();
        }
    }

    public void UpdateCompletedLevels() {
        if (PlayerPrefs.GetInt(CompletedPref, 1) >= SceneManager.GetActiveScene().buildIndex + 1)
            return;

        PlayerPrefs.SetInt(CompletedPref, SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }
}