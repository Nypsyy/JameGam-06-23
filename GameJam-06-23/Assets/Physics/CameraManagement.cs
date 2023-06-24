using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManagement : MonoBehaviour
{
    public Transform Player;
    public float dampTime = 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startCamera()
    {

    }

    public void FlareCamera()
    {
        
    }

    public void MCCamera()
    {
        cameraPos = new Vector3(Player.position.x, Player.position.y, Player.position.z);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
    }
}
