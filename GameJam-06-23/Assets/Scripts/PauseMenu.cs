using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject commandsUI;
    public GameObject tutorialUI;

    private bool _isPaused;

    private void Start() {
        ShowTutorial();
    }

    public void Update() {
        if (!Input.GetKeyDown(KeyCode.Escape) || tutorialUI.activeSelf) return;
        
        if (_isPaused) {
            if (pauseMenuUI.activeSelf) {
                ResumeGame();
            }
            else if (commandsUI.activeSelf) {
                HideCommands();
            }
        }
        else {
            PauseGame();
        }
    }

    public void PauseGame() {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        _isPaused = false;
        
        pauseMenuUI.SetActive(false);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void ShowCommands() {
        Time.timeScale = 0f;
        _isPaused = true;
        
        commandsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void HideCommands() {
        pauseMenuUI.SetActive(true);
        commandsUI.SetActive(false);
    }
    
    private void ShowTutorial() {
       Time.timeScale = 0f;
       
       tutorialUI.SetActive(true);
    }
}