using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CameraManagement : MonoBehaviour
{
    public Transform player;
    public float dampTime = 0.4f;
    private Vector3 _cameraPos;
    private Vector3 _velocity = Vector3.zero;

    public void startCamera() {
    }

    public void FlareCamera() {
    }

    public void MCCamera() {
        var position = player.position;
        _cameraPos = new Vector3(position.x, position.y, position.z);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, _cameraPos, ref _velocity, dampTime);
    }
}