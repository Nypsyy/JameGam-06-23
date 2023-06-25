using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    private PolygonCollider2D _collider2D;
    private Rigidbody2D _rb;
    public PhysicsMaterial2D inert;
    private bool _isObjectCreated;
    private GameObject _flare;
    private CameraControls _cameraControls;
    private BeanMovement _beanMovement;
    public UnityEvent destroyFlare;

    private void Start() {
        _collider2D = GetComponent<PolygonCollider2D>();
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

        if (_rb.velocity.magnitude < 0.05) {
            Invoke("DestroyFlare", 5);
        }
    }

    private void DestroyFlare()
    {
        Destroy(_flare);
        _cameraControls.MoveCameraSurface();
        _beanMovement.EnableInputs();
    }

    private void Awake() {
        _cameraControls = FindObjectOfType<CameraControls>();
        _beanMovement = FindObjectOfType<BeanMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Ground")) {
            _collider2D.sharedMaterial = inert;
        }
    }
}