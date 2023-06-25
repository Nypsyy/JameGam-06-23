using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class BeanMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float horizontalSpeed = 10f;
    public float horizontalAcceleration = 2f;
    public float maxFallSpeed = 25f;
    public float drag = 10f;

    public UnityEvent onLandEvent;
    public UnityEvent onFallEvent;
    public UnityEvent onJumpEvent;
    public UnityEvent onThrowEvent;
    public UnityEvent onLaunchEvent;

    private Rigidbody2D _rb2d;
    private InputManager _inputManager;
    private Vector2 _moveVector;
    private float _inputMove;
    private bool _isJumping;
    private bool _isThrowing;
    private bool _isGrounded;
    private bool _isFlipped;

    public void OnJump() {
        _isGrounded = false;
    }

    public void OnFall() {
        _isGrounded = false;
    }

    public void OnLand() {
        _isGrounded = true;
    }

    public void OnThrow() {
        _isThrowing = true;
        _rb2d.velocity = Vector2.zero;
    }

    public void OnLaunch() {
        _isThrowing = false;
    }

    public void OnDeath() {
        var light2D = GetComponentInChildren<Light2D>();

        _rb2d.simulated = false;
        light2D.enabled = false;
    }

    public void DisableInputs() {
        _inputManager.Disable();
    }

    private void StartJump() {
        if (!_isGrounded)
            return;

        _isJumping = true;
    }

    private void TryFlipSprite() {
        if ((!_isFlipped || _moveVector.x <= 0) && (_isFlipped || _moveVector.x >= 0))
            return;

        _isFlipped = !_isFlipped;

        var selfTransform = transform;
        var currentScale = selfTransform.localScale;
        currentScale.x *= -1;
        selfTransform.localScale = currentScale;
    }

    private void TryThrow() {
        if (_isGrounded) {
            onThrowEvent.Invoke();
        }
    }


    private void Throw() {
        if (_isThrowing) {
            onLaunchEvent.Invoke();
        }
    }

    private void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
        _inputManager = new InputManager();

        // Input events
        _inputManager.Player.LongJump.started += _ => StartJump();
        _inputManager.Player.LongJump.performed += _ => _isJumping = false;
        _inputManager.Player.LongJump.canceled += _ => _isJumping = false;
        _inputManager.Player.Throw.performed += _ => TryThrow();
        _inputManager.Player.Throw.canceled += _ => Throw();
        _inputManager.Player.Move.performed += context => _inputMove = context.ReadValue<float>();
        _inputManager.Player.Move.canceled += _ => _inputMove = 0f;

        // Game events
        onLandEvent ??= new UnityEvent();
        onFallEvent ??= new UnityEvent();
        onJumpEvent ??= new UnityEvent();
        onThrowEvent ??= new UnityEvent();
        onLaunchEvent ??= new UnityEvent();
    }

    private void Update() {
        TryFlipSprite();
    }

    private void FixedUpdate() {
        if (_isThrowing)
            return;
        
        // If we jump, we get a constant velocity. Use physics otherwise
        _moveVector.y = _isJumping ? jumpForce : _rb2d.velocity.y;
        // If grounded, constant velocity
        if (_isGrounded) {
            _moveVector.x = horizontalSpeed * _inputMove;
        }
        else {
            // Simulate acceleration in the air
            _moveVector.x += horizontalAcceleration * _inputMove;
            if (_moveVector.x > horizontalSpeed) _moveVector.x = horizontalSpeed;
            else if (_moveVector.x < -horizontalSpeed) _moveVector.x = -horizontalSpeed;

            // Drags the rigidbody when no inputs
            if (_inputMove == 0f) {
                _moveVector.x -= drag * _moveVector.x;
            }
        }

        // Maximum fall speed for gameplay readability
        _moveVector.y = Mathf.Max(_moveVector.y, -maxFallSpeed);

        _rb2d.velocity = _moveVector;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Ground")) {
            onLandEvent.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (!other.collider.CompareTag("Ground"))
            return;

        if (_isJumping) {
            onJumpEvent.Invoke();
        }
        else {
            onFallEvent.Invoke();
        }
    }

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }
}