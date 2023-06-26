using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CameraControls _cameraControls;
    private BeanMovement _beanMovement;
    private bool _destroyed;
    private float _torqueValue;

    private static Projectile _instance;

    private void DestroyFlare() {
        Destroy(gameObject);
        _cameraControls.MoveCameraSurface();
        _beanMovement.EnableInputs();
    }

    private void Awake() {
        // Object created here
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        _cameraControls = FindObjectOfType<CameraControls>();
        _beanMovement = FindObjectOfType<BeanMovement>();
    }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _torqueValue = (_beanMovement.isFlipped) ? -0.5f : 0.5f;
        _rb.AddTorque(_torqueValue, ForceMode2D.Impulse);
    }

    private void Update() {
        if (!(_rb.velocity.magnitude < .05f) || _destroyed)
            return;

        Invoke(nameof(DestroyFlare), 2f);
        _destroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("FlareDestruct"))
            return;

        Destroy(gameObject);
        _beanMovement.EnableInputs();
    }
}