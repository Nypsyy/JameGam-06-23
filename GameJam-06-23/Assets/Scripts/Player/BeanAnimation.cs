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
    private short _beanStateIndex;

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
    
    

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
        _animator = GetComponent<Animator>();
        _spriteLibrary = GetComponent<SpriteLibrary>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            _spriteLibrary.spriteLibraryAsset = assets[0];
        }

        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            _spriteLibrary.spriteLibraryAsset = assets[1];
        }

        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            _spriteLibrary.spriteLibraryAsset = assets[2];
        }

        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            _spriteLibrary.spriteLibraryAsset = assets[3];
        }

        _animator.SetFloat(AnimatorSpeed, Mathf.Abs(rb2d.velocity.x));
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
        _audioManager.Play("Explosion");
        _animator.SetBool(Deadge, true);
        gameObject.GetComponent<SpriteRenderer>().material = spriteDefault;
    }

    public void OnWinAnimation() {
        _audioManager.Play("Victoire");
        _animator.SetBool(AnimatorWin, true);
    }

    public void OnThrowAnimation() {
        _animator.SetBool(AnimatorIsThrowing, true);
    }
    
    public void OnLaunchAnimation() {
        _audioManager.Play("Throw");
        _animator.SetBool(AnimatorIsThrowing, false);
        _animator.SetBool(AnimatorIsLaunching, true);
    }

    public void UpdateBeanState() {
        if (_beanStateIndex < 3) {
            _beanStateIndex++;
        }

        _spriteLibrary.spriteLibraryAsset = assets[_beanStateIndex];
    }


    public void HandlerEvent(string name)
    {
        if (name == "launch")
        {
            _animator.SetBool(AnimatorIsLaunching, false);
        }
    }
}