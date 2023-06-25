using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject MCSprite;

    [SerializeField]
    private GameObject MC;

    public UnityEvent onFallEvent;

    
    void Awake()
    {
        onFallEvent ??= new UnityEvent();
    }   
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {

            onFallEvent.Invoke(); 
            // MC.GetComponent<MCmove>().isFalling = true;

        }
    }
}
