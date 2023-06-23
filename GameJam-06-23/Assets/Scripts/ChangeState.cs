using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.Rendering.Universal;

public class ChangeState : MonoBehaviour
{

    public Light2D Light2D;
    public SpriteLibrary SpriteLibrary;

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
            SpriteLibrary.spriteLibraryAsset = states[i];
            Light2D.intensity-=0.5f;
    }
}
