using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

public class BeanSrpite : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator animator;
    public SpriteLibrary SpriteLibrary;
    public SpriteLibraryAsset[] assets;


    private float _horizontalSpeed;
    private Vector2 _moveVector;
    private bool _isJumping;
    private bool _isGrounded;

    public void OnJumpAnimation() {
        animator.SetBool("IsJumping", true);    
        animator.SetBool("IsFalling", false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            SpriteLibrary.spriteLibraryAsset = assets[0];
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            SpriteLibrary.spriteLibraryAsset = assets[1];
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            SpriteLibrary.spriteLibraryAsset = assets[2];
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            SpriteLibrary.spriteLibraryAsset = assets[3];
        }


        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }

    public void OnLandAnimation() {
        animator.SetBool("IsFalling", false);
        animator.SetBool("IsJumping", false);
    }

    public void OnFallAnimation() {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", true);
    }


    public void victory() {
        animator.SetBool("Win", true);
    }


    public void onThrowAnimation(){
        animator.SetBool("IsThrowing", true);
    }
}
