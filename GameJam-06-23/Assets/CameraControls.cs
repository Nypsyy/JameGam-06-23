using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CameraControls : MonoBehaviour
{
    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveCameraMC();
        }

        if (collision.gameObject.CompareTag("Flare"))
        {
            MoveCameraFlare();
        }
    }

    public void MoveCameraFlare()
    {
        cameraSurface.SetActive(false);
        cameraFlare.SetActive(true);
        cameraMC.SetActive(false);
    }

    public void MoveCameraMC()
    {
        cameraSurface.SetActive(false);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(true);
    }

}
