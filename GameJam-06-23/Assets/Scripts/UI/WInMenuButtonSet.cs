using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WInMenuButtonSet : MonoBehaviour
{
    public GameObject buttonNext;
    public GameObject buttonMenu;
    private void OnEnable() {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            buttonNext.SetActive(false);
            buttonMenu.SetActive(true);
        }
    }
}
