using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FlareCollision : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;
    private GameObject ground;

    public PhysicsMaterial2D inert;

    private void Start() {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            capsuleCollider.sharedMaterial = inert;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
        }
    }
}