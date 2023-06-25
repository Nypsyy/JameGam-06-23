using UnityEngine;
using UnityEngine.Events;

public class FallingTrigger : MonoBehaviour
{
    public UnityEvent onFallEvent;

    private void Awake() {
        onFallEvent ??= new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            onFallEvent.Invoke();
        }
    }
}