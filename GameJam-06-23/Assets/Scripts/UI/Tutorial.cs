using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public BeanMovement beanMovement;

    public void HideTutorial(GameObject obj) {
        Time.timeScale = 1f;
        obj.SetActive(false);
    }

    private void OnEnable() {
        beanMovement.DisableInputs();
    }
}