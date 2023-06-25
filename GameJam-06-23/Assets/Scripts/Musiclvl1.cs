using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioManager.Play("Level1");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
