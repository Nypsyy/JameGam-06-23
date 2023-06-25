using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioManager _audioManager;
    public GameObject pauseMenuUI;
    public GameObject commandsUI;
    public GameObject tutorialUI;
    public LevelData levelData;

    private InputManager _inputManager;
    private bool _isPaused;

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
        _inputManager = new InputManager();

        _inputManager.UI.Cancel.performed += _ => ManagePause();
    }

    private void Start() {

        if (!levelData.showTutorial)
            return;

        ShowTutorial();
        levelData.showTutorial = false;
    }

    private void ManagePause() {
        if (_isPaused && !tutorialUI.activeSelf) {
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

    private void PauseGame() {
        _audioManager.Play("Menu");  
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame() {
        _audioManager.Play("Menu");  
        Time.timeScale = 1f;
        _isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void LoadMainMenu() {
        _audioManager.Play("Menu");    
        _audioManager.Stop("Level1");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ShowCommands() {
        _audioManager.Play("Menu");  
        Time.timeScale = 0f;
        _isPaused = true;

        commandsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void HideCommands() {
        _audioManager.Play("Menu");  
        pauseMenuUI.SetActive(true);
        commandsUI.SetActive(false);
    }

    private void ShowTutorial() {
        Time.timeScale = 0f;

        tutorialUI.SetActive(true);
    }

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }
}