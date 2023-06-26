using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public BeanMovement beanMovement;
    public UnityEvent onCloseTutorialEvent;

    
    public void HideTutorial() {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    private void Awake() {
        onCloseTutorialEvent ??= new UnityEvent();
    }

    private void OnEnable() {
        beanMovement.DisableInputs();
    }
}