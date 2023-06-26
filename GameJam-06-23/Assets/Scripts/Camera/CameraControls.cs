using Cinemachine;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;
    public GameObject winPointCamera;
    
    private GameObject _newFlare;
    private CinemachineVirtualCamera _cvcFlare;
    private Transform _target;

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            MoveCameraMC();
        }
        else if (col.CompareTag("Flare")) {
            _newFlare = col.gameObject;
            MoveCameraFlare();
        }
    }

    private void MoveCameraFlare() {
        cameraSurface.SetActive(false);
        cameraMC.SetActive(false);
        _cvcFlare = cameraFlare.GetComponent<CinemachineVirtualCamera>();
        _target = _newFlare.transform;
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

    public void ToggleWinCamera() {
        var vcam = cameraMC.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = winPointCamera.transform;
    }
}