using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Tutorial2 : MonoBehaviour
{
    public BeanMovement beanMovement;
    public UnityEvent onCloseTutorialEvent;
    private readonly WaitForSeconds _wait = new(0.3f);

    
    public void HideTutorial() {
        gameObject.SetActive(false);
    }

    private void Awake() {
        onCloseTutorialEvent ??= new UnityEvent();
        
    }


    private IEnumerator LoadIndexedScene() {
        yield return _wait;
       
        if (Input.anyKey)
        {
            onCloseTutorialEvent.Invoke();
        }
    }

    private void OnEnable() {
        beanMovement.DisableInputs();
    }

    private void Update() {
        backInTime();
        StartCoroutine(LoadIndexedScene());
    }
    
    
    public void backInTime()
    {
        beanMovement.DisableInputs();
        Time.timeScale = 1f;
    }
}