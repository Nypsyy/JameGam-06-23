using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject commandsUI;
    public GameObject commandsUI2;
    public GameObject commandsUI3;
    public GameObject tutorialUI;
    public GameObject tutorialUI2;
    public GameObject tutorialUI3;
    public BeanMovement beanMovement;
    public LevelData levelData;

    private InputManager _inputManager;
    private AudioManager _audioManager;
    private bool _isPaused;

    private const string SelectButtonSound = "SelectButton";

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
        if (_isPaused) {
            if (tutorialUI.activeSelf || tutorialUI2.activeSelf || tutorialUI3.activeSelf)
                return;
            
            if (pauseMenuUI.activeSelf) {
                ResumeGame();
            }
            else if (commandsUI.activeSelf || commandsUI2.activeSelf || commandsUI3.activeSelf) {
                HideCommands();
            }
        }
        else {
            PauseGame();
        }
    }

    private void PauseGame() {
        _audioManager.Play(SelectButtonSound);
        beanMovement.isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame() {
        _audioManager.Play(SelectButtonSound);
        beanMovement.isPaused = false;
        Time.timeScale = 1f;
        _isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void LoadMainMenu() {
        _audioManager.Play(SelectButtonSound);
        _audioManager.Stop(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ShowCommands() {
        _audioManager.Play(SelectButtonSound);
        Time.timeScale = 0f;
        _isPaused = true;

        commandsUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void HideCommands() {
        _audioManager.Play(SelectButtonSound);
        pauseMenuUI.SetActive(true);
        commandsUI.SetActive(false);
        commandsUI2.SetActive(false);
        commandsUI3.SetActive(false);
    }

    private void ShowTutorial() {
        Time.timeScale = 0f;
        _isPaused = true;
        Debug.Log(_isPaused);
        tutorialUI.SetActive(true);
    }

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }

    public void DisableInput() {
        _inputManager.Disable();
    }
}