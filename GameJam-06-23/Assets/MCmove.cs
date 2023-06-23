using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MCmove : MonoBehaviour
{
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        var rb=GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(10,10),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
    }
}
