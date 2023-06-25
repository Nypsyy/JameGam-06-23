using UnityEngine;
using UnityEngine.U2D.Animation;

public class BeanAnimation : MonoBehaviour
{
    private AudioManager _audioManager;
    public Rigidbody2D rb2d;
    public SpriteLibraryAsset[] assets;
    public Material spriteDefault;

    private Animator _animator;
    private SpriteLibrary _spriteLibrary;

    private float _horizontalSpeed;
    private Vector2 _moveVector;
    private bool _isJumping;
    private bool _isGrounded;
    private short _currentAssetIndex;

    private static readonly int AnimatorIsJumping = Animator.StringToHash("IsJumping");
    private static readonly int AnimatorIsFalling = Animator.StringToHash("IsFalling");
    private static readonly int AnimatorSpeed = Animator.StringToHash("Speed");
    private static readonly int AnimatorWin = Animator.StringToHash("Win");
    private static readonly int AnimatorIsThrowing = Animator.StringToHash("IsThrowing");
    private static readonly int AnimatorIsLaunching = Animator.StringToHash("IsLaunching");
    private static readonly int Deadge = Animator.StringToHash("Deadge");

    public void OnJumpAnimation() {
        _animator.SetBool(AnimatorIsJumping, true);
        _animator.SetBool(AnimatorIsFalling, false);
    }

    public void OnLandAnimation() {
        _animator.SetBool(AnimatorIsFalling, false);
        _animator.SetBool(AnimatorIsJumping, false);
    }

    public void OnFallAnimation() {
        _animator.SetBool(AnimatorIsJumping, false);
        _animator.SetBool(AnimatorIsFalling, true);
    }

    public void OnDeathAnimation() {
        if (_audioManager != null) {
            _audioManager.Play("Explosion");
        }

        _animator.SetBool(Deadge, true);
        gameObject.GetComponent<SpriteRenderer>().material = spriteDefault;
    }

    public void OnWinAnimation() {
        if (_audioManager != null) {
            _audioManager.Play("Victoire");
        }

        _animator.SetBool(AnimatorWin, true);
    }

    public void OnThrowAnimation() {
        _animator.SetBool(AnimatorIsThrowing, true);
    }

    public void OnLaunchAnimation() {
        if (_audioManager != null) {
            _audioManager.Play("Throw");
        }

        _animator.SetBool(AnimatorIsThrowing, false);
        _animator.SetBool(AnimatorIsLaunching, true);
        

    }

    public void StopLaunchAnimation() {
        _animator.SetBool(AnimatorIsLaunching, false);
        if (_currentAssetIndex < 3) {
            _currentAssetIndex++;
        }

        _spriteLibrary.spriteLibraryAsset = assets[_currentAssetIndex];
    }
    
    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
        _animator = GetComponent<Animator>();
        _spriteLibrary = GetComponent<SpriteLibrary>();
    }

    private void Update() {
        _animator.SetFloat(AnimatorSpeed, Mathf.Abs(rb2d.velocity.x));
    }
}