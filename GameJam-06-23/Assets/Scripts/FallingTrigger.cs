using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject MCSprite;

    [SerializeField]
    private GameObject MC;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            MC.GetComponent<MCmove>().isFalling = true;
            MCSprite.GetComponent<Animator>().Play("fall1");
        }
    }
}
