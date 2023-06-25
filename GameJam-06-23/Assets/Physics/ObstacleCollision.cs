using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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


    [SerializeField]
    private Animator animator;


    public UnityEvent onDeathevent;
    
    void Awake()
    {
        onDeathevent ??= new UnityEvent();
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
            animator.SetBool("Deadge",true);
            rb.velocity = new Vector2(0f, 0f);
            MC.GetComponent<MCmove>().stopMovement();
            rb.gravityScale  = 0f;
            Destroy(light);
            onDeathevent.Invoke();

           
        }
    }

}
