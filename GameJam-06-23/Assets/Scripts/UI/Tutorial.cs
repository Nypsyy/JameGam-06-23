using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    public BeanMovement beanMovement;
    public UnityEvent onCloseTutorialEvent;

    
    public void HideTutorial() {
        gameObject.SetActive(false);
    }

    private void Awake() {
        onCloseTutorialEvent ??= new UnityEvent();
    }

    private void OnEnable() {
        beanMovement.DisableInputs();
    }

    private void Update() {
        if (Input.anyKey) {
            onCloseTutorialEvent.Invoke();
        }
    }


}