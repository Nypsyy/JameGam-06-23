using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Update() {
        if (Input.anyKey) {
            HideTutorial();
        }
    }

    private void HideTutorial() {
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}