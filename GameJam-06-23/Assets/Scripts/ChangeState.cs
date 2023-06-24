using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.SceneManagement;

public class ChangeState : MonoBehaviour
{

    [SerializeField]
    private SpriteLibraryAsset[] states;
    private int i = 0;
    [SerializeField]
    private GameObject MC;
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

            if(message == "death"){
                gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if(message == "change"){
                if(i<3){
                    i++;
                }
                gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = states[i];
                MC.GetComponent<MCmove>().resetSpeed();

            }

    }
}
