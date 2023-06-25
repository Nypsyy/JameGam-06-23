using Cinemachine;
using UnityEngine;

public class CameraGround : MonoBehaviour
{
    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;

    public GameObject winCamPoint;
    private CinemachineVirtualCamera _winCam;

    private Transform _target;
    //private GameObject camWin;
    //[SerializeField] private float upvalue;
    //private CinemachineFramingTransposer trans;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Flare")) {
            MoveCameraSurface();
        }

        if (collision.gameObject.CompareTag("Player")) {
            MoveCameraWin();
        }
    }

    public void MoveCameraWin() {
        //winCam = cameraMC.GetComponent<CinemachineVirtualCamera>();
        //target = winCamPoint.transform;
        //winCam.Follow = target;

        //Debug.Log("inchallah ça marche");
        //camWin = cameraMC;
        //trans = camWin.GetComponentInChildren<CinemachineFramingTransposer>();
        //trans.m_TrackedObjectOffset = this.transform.localToWorldMatrix * new Vector3(0, upvalue, 0);
    }

    private void MoveCameraSurface() {
        cameraSurface.SetActive(true);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(false);
    }
}