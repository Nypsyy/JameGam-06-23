using UnityEngine;

public class FlareCollision : MonoBehaviour
{
    private CapsuleCollider2D _capsuleCollider;

    public PhysicsMaterial2D inert;

    private void Start() {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            _capsuleCollider.sharedMaterial = inert;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
        }
    }
}