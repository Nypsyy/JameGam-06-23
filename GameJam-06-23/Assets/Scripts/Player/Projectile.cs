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
    private bool destroyed;
    private float flipvalue;

    private void Start() {
        _collider2D = GetComponent<PolygonCollider2D>();
        if (!_isObjectCreated) {
            // Créer l'objet ici
            _rb = GetComponent<Rigidbody2D>();
            _isObjectCreated = true;
        }

        if (_beanMovement._isFlipped == false ) {
            flipvalue = 0.5f;
        }
        else
        {
            flipvalue = -0.5f;
        }

        _rb.AddTorque(flipvalue, ForceMode2D.Impulse);

        _flare = GameObject.FindGameObjectWithTag("Flare");
    }

    private void Update() {

        if (_rb.velocity.magnitude < 0.05 && destroyed == false) {
            Invoke("DestroyFlare", 2);
            destroyed = true;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FlareDestruct"))
        {
            Destroy(_flare);
            _beanMovement.EnableInputs();
        }
    }
}