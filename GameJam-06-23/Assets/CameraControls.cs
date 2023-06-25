using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CameraControls : MonoBehaviour
{
    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;
    public GameObject newFlare;
    private CinemachineVirtualCamera CVCFlare;
    private Transform target;

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
            newFlare = collision.gameObject;
            MoveCameraFlare();
        }
    }

    public void MoveCameraFlare()
    {
        cameraSurface.SetActive(false);
        cameraMC.SetActive(false);
        CVCFlare = cameraFlare.GetComponent<CinemachineVirtualCamera>();
        target = newFlare.transform;
        CVCFlare.Follow = target;
        cameraFlare.SetActive(true);
    }

    public void MoveCameraMC()
    {
        cameraSurface.SetActive(false);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(true);
    }

    public void MoveCameraSurface()
    {
        cameraSurface.SetActive(true);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(false);
    }

}
