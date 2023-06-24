using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;
    Rigidbody2D rb;
    public PhysicsMaterial2D inert;
    private bool isObjectCreated = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (!isObjectCreated)
        {
            // Créer l'objet ici
            rb = GetComponent<Rigidbody2D>();
            isObjectCreated = true;
        }
    }

        
    

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            capsuleCollider.sharedMaterial = inert;
        }
    }

}
