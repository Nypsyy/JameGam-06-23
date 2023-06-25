using UnityEngine;
using UnityEngine.Events;

public class Win : MonoBehaviour
{
    public UnityEvent onWinEvent;

    private void Awake() {
        onWinEvent ??= new UnityEvent();
    }


    private void Start() {
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            onWinEvent.Invoke();
        }
    }
}