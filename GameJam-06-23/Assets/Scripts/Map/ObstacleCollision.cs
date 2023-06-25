using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public UnityEvent onDeathEvent;

    private static readonly WaitForSeconds Wait = new(.7f);

    private void Awake() {
        onDeathEvent ??= new UnityEvent();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Player"))
            return;

        onDeathEvent.Invoke();
        StartCoroutine(ReloadScene());
    }

    private static IEnumerator ReloadScene() {
        yield return Wait;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}