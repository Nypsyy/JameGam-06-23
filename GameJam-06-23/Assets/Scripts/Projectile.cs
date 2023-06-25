using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D rb;
    public PhysicsMaterial2D inert;
    private bool isObjectCreated = false;
    private GameObject flare;
    private CameraControls CameraControls; 

    // Start is called before the first frame update
    private void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        if (!isObjectCreated)
        {
            // Créer l'objet ici
            rb = GetComponent<Rigidbody2D>();
            isObjectCreated = true;
        }
        flare = GameObject.FindGameObjectWithTag("Flare");

    }

        
    

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude <0.05)
        {
            //mettre un timer
            Destroy(flare);
            CameraControls.MoveCameraSurface();
        }

    }

    private void Awake()
    {
        CameraControls = FindObjectOfType<CameraControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Ground"))
        {
            capsuleCollider2D.sharedMaterial = inert;
        }
    }

}
