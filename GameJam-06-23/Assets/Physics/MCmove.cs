using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MCmove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpingPower = 20f;
    [SerializeField]
    private GameObject MCSprite;
    private float horizontal;
    private bool isFacingRight = true;
    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool isJumping = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask surfaceGround;
    
    public bool isFalling = false;

    public bool isThrowing = false;

    public bool noFlip = false;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetMouseButtonDown(1) && IsGrounded()){
            animate("throw1");
            stopMovement();
        }

        
        if(!isJumping){
            walk();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animate("jump1");
        

        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            isJumping = false;
        }

        Flip();
    }

    private void FixedUpdate()
    {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
       
    }

    public void walk(){
        var anim = MCSprite.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(!(anim).Contains("explode") && !(anim).Contains("throw1")) {
        
            if((anim).Contains("jump") || (anim).Contains("fall")){
                if(Physics2D.OverlapCircle(groundCheck.position, 0.5f, surfaceGround)){
                    animate("idle1");
                }
            }
            else if(horizontal == 0){
                // Debug.Log(anim);
                animate("idle1");
                
            }
            else if(horizontal == -1 || horizontal == 1  ){
                animate("walk1");
            }
        }
    }

    private bool IsGrounded()
    {
        Debug.Log("oui");
        var anim = MCSprite.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(!(anim).Contains("jump") && !(anim).Contains("explode")) {
            animate("idle1");
        }

        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, surfaceGround);
    }

    private void Flip()
    {

        if(!noFlip){
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

    }


    private void animate(string name){
        if(!isFalling && !isThrowing){
            if(name == "throw1"){
                isThrowing = true;
            }
            MCSprite.GetComponent<Animator>().Play(name);
        }
    }

    public void resetSpeed(){
        moveSpeed = 5f;
        jumpingPower = 8f;
        isThrowing = false;
        noFlip = false;
    }

    public void stopMovement(){
        noFlip = true;
        moveSpeed = 0f;
        jumpingPower = 0f;
    }
}
  
