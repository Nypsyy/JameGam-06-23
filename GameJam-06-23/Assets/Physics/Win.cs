using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Win : MonoBehaviour
{
    public Text winText;
    [SerializeField]
    private GameObject MCSprite;


    public UnityEvent win; 

    // Start is called before the first frame update
    void Awake()
    {
      win ??= new UnityEvent();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            gameObject.GetComponent<MCmove>().noFlip = true;
            gameObject.GetComponent<MCmove>().stopMovement();
            winText.gameObject.SetActive(true);
            win.Invoke();

        }
    }
}
