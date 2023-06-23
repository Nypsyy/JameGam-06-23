using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public int NbDeath;
    public Text nbdeathText;

    public void addDeath()
    {
        NbDeath = NbDeath + 1;
        nbdeathText.text = NbDeath.ToString(); 
    }

    public
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
