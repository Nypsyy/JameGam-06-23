using UnityEngine;
using UnityEngine.U2D.Animation;

public class BeanSrpite : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteLibrary spriteLibrary;
    public SpriteLibraryAsset[] assets;

    private float _horizontalSpeed;
    private Vector2 _moveVector;
    private bool _isJumping;
    private bool _isGrounded;
    
    private static readonly int AnimatorIsJumping = Animator.StringToHash("IsJumping");
    private static readonly int AnimatorIsFalling = Animator.StringToHash("IsFalling");
    private static readonly int AnimatorSpeed = Animator.StringToHash("Speed");
    private static readonly int AnimatorWin = Animator.StringToHash("Win");
    private static readonly int AnimatorIsThrowing = Animator.StringToHash("IsThrowing");

    public void OnJumpAnimation() {
        animator.SetBool(AnimatorIsJumping, true);
        animator.SetBool(AnimatorIsFalling, false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            spriteLibrary.spriteLibraryAsset = assets[0];
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            spriteLibrary.spriteLibraryAsset = assets[1];
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            spriteLibrary.spriteLibraryAsset = assets[2];
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            spriteLibrary.spriteLibraryAsset = assets[3];
        }


        animator.SetFloat(AnimatorSpeed, Mathf.Abs(rb2d.velocity.x));
    }

    public void OnLandAnimation() {
        animator.SetBool(AnimatorIsFalling, false);
        animator.SetBool(AnimatorIsJumping, false);
    }

    public void OnFallAnimation() {
        animator.SetBool(AnimatorIsJumping, false);
        animator.SetBool(AnimatorIsFalling, true);
    }

    public void victory() {
        animator.SetBool(AnimatorWin, true);
    }
    
    public void onThrowAnimation() {
        animator.SetBool(AnimatorIsThrowing, true);
    }
}