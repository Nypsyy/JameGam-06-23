using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject winMenuUI;



    private void Start() {
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinMenu() {
        StartCoroutine(ShowWinMenu());
    }

    private IEnumerator ShowWinMenu() {
        yield return new WaitForSeconds(1f);
        winMenuUI.SetActive(true);
    }
}