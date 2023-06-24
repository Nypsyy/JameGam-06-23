using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    //private DeathCount deathCount;
    // Start is called before the first frame update

    [SerializeField]
    private GameObject MCSprite;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField]
    private GameObject MC;

    
    [SerializeField]
    private GameObject light;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //lancer animation de mort
            Debug.Log("Censé perdre");
            //deathCount.addDeath();
            rb.velocity = new Vector2(0f, 0f);
            MC.GetComponent<MCmove>().stopMovement();
            rb.gravityScale  = 0f;
            Destroy(light);
            MCSprite.GetComponent<Animator>().Play("explode");
        }
    }

}
