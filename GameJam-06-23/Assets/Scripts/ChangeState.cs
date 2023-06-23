using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ChangeState : MonoBehaviour
{

    [SerializeField]
    private SpriteLibraryAsset[] states;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AlertObservers(string message)
    {

        
            if(i<3){
                i++;
            }
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = states[i];
    }
}
