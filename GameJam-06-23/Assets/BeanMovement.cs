using UnityEngine;
using UnityEngine.Events;

public class BeanMovement : MonoBehaviour
{
    public UnityEvent onLandEvent;
    public UnityEvent onFallEvent;
    public UnityEvent onJumpEvent;
    public Rigidbody2D rb2d;

    public float jumpForce = 10f;
    public float horizontalSpeedFactor = 10f;


    private PlayerActions _playerActions;
    private Vector2 _moveVector;
    private float _horizontalSpeed;
    private float _previousYSpeed;
    private bool _isJumping;
    private bool _isGrounded;

    public void OnJump() {
        _isGrounded = false;
    }

    public void OnLand() {
        _isGrounded = true;
    }

    private void StartJump() {
        if (!_isGrounded) return;
        _isJumping = true;
    }

    private void Awake() {
        _playerActions = new PlayerActions();

        _playerActions.Main.LongJump.started += _ => StartJump();
        _playerActions.Main.LongJump.performed += _ => _isJumping = false;
        _playerActions.Main.LongJump.canceled += _ => _isJumping = false;

        onLandEvent ??= new UnityEvent();
        onFallEvent ??= new UnityEvent();
        onJumpEvent ??= new UnityEvent();
    }

    private void Update() {
        _moveVector.Set(horizontalSpeedFactor * _playerActions.Main.Move.ReadValue<float>(), rb2d.velocity.y);
        
        if (_isJumping) {
            _moveVector.y = jumpForce;
        }

        if (_moveVector.y < 0 && _previousYSpeed >= 0) {
            onFallEvent.Invoke();
        }

        _previousYSpeed = _moveVector.y;
    }
    
    private void FixedUpdate() {
        rb2d.velocity = _moveVector;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Ground")) {
            onLandEvent.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.CompareTag("Ground") && _isJumping) {
            onJumpEvent.Invoke();
        }
    }

    private void OnEnable() {
        _playerActions.Enable();
    }

    private void OnDisable() {
        _playerActions.Disable();
    }
}