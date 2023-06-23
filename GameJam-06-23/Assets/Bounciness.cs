using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bounciness : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;
    private GameObject ground;
    public PhysicsMaterial2D inert;
    bool hitGround = false;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        var material = new PhysicsMaterial2D();
        material.bounciness = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(capsuleCollider.sharedMaterial.bounciness);
        if (hitGround == true)
        {
            capsuleCollider.sharedMaterial = inert;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hitGround = true;
        }
    }
}
