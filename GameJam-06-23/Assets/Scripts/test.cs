using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class test : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject MC;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            MC.GetComponent<Animator>().Play("jump1");
        }
        else if(Input.GetKeyUp(KeyCode.Q)){
            MC.GetComponent<Animator>().Play("throw1");
        }
        else if(Input.GetKeyUp(KeyCode.D)){
            MC.GetComponent<Animator>().Play("fall1");
        }
    }




}
