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
    private CinemachineVirtualCamera _cvcFlare;
    private Transform _target;


    public void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            MoveCameraMC();
        }

        if (col.CompareTag("Flare")) {
            newFlare = col.gameObject;
            MoveCameraFlare();
        }
    }

    private void MoveCameraFlare() {
        cameraSurface.SetActive(false);
        cameraMC.SetActive(false);
        _cvcFlare = cameraFlare.GetComponent<CinemachineVirtualCamera>();
        _target = newFlare.transform;
        _cvcFlare.Follow = _target;
        cameraFlare.SetActive(true);
    }

    private void MoveCameraMC() {
        cameraSurface.SetActive(false);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(true);
    }

    public void MoveCameraSurface() {
        cameraSurface.SetActive(true);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(false);
    }
}