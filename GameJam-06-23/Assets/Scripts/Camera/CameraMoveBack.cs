using UnityEngine;

public class CameraMoveBack : MonoBehaviour
{
    public GameObject cameraSurface;
    public GameObject cameraFlare;
    public GameObject cameraMC;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Flare")) {
            MoveCameraSurface();
        }
    }

    private void MoveCameraSurface() {
        cameraSurface.SetActive(true);
        cameraFlare.SetActive(false);
        cameraMC.SetActive(false);
    }
}