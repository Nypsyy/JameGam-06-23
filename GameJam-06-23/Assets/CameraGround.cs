using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CameraGround : MonoBehaviour
{

    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;

    public GameObject winCamPoint;
    private CinemachineVirtualCamera winCam;
    private Transform target;
    //private GameObject camWin;
    //[SerializeField] private float upvalue;
    //private CinemachineFramingTransposer trans;
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
        if (collision.gameObject.CompareTag("Flare"))
        {
            MoveCameraSurface();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveCameraWin();
        }
    }

    public void MoveCameraWin()
    {
        winCam = cameraMC.GetComponent<CinemachineVirtualCamera>();
        target = winCamPoint.transform;
        winCam.Follow = target;

        //Debug.Log("inchallah ça marche");
        //camWin = cameraMC;
        //trans = camWin.GetComponentInChildren<CinemachineFramingTransposer>();
        //trans.m_TrackedObjectOffset = this.transform.localToWorldMatrix * new Vector3(0, upvalue, 0);

    }

    public void MoveCameraSurface()
    {
        cameraSurface.SetActive(true);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(false);
    }


}
