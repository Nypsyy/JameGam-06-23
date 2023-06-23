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
        if (Input.GetKeyUp(KeyCode.Keypad0)){
            MC.GetComponent<Animator>().Play("jump1");
        }
        else if(Input.GetKeyUp(KeyCode.Keypad1)){
            MC.GetComponent<Animator>().Play("throw1");
        }
        else if(Input.GetKeyUp(KeyCode.Keypad2)){
            MC.GetComponent<Animator>().Play("fall1");
        }
        else if(Input.GetKeyUp(KeyCode.Keypad3)){
            MC.GetComponent<Animator>().Play("walk1");
        }
        else if(Input.GetKeyUp(KeyCode.Keypad4)){
            MC.GetComponent<Animator>().Play("explode");
        }
        
    }




}
