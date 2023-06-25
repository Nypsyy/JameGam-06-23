using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private CapsuleCollider2D _capsuleCollider2D;
    private Rigidbody2D _rb;
    public PhysicsMaterial2D inert;
    private bool _isObjectCreated;
    private GameObject _flare;
    private CameraControls _cameraControls;

    private void Start() {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        if (!_isObjectCreated) {
            // Créer l'objet ici
            _rb = GetComponent<Rigidbody2D>();
            _isObjectCreated = true;
        }

        _flare = GameObject.FindGameObjectWithTag("Flare");
    }

    private void Update() {
        var velocity = _rb.velocity;
        var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(_rb.velocity.magnitude);
        if (_rb.velocity.magnitude < 0.05) {
            //mettre un timer
            Destroy(_flare);
            _cameraControls.MoveCameraSurface();
        }
    }

    private void Awake() {
        _cameraControls = FindObjectOfType<CameraControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Ground")) {
            _capsuleCollider2D.sharedMaterial = inert;
        }
    }
}