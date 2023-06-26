using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject mainUI;
    public GameObject optionsUI;
    public GameObject levelsUI;
    public GameObject[] levelButtons;
    public LevelData levelData;

    private AudioManager _audioManager;
    private InputManager _inputManager;
    private int _completed;
    private readonly WaitForSeconds _wait = new(1.45f);

    private static readonly int IsPlay = Animator.StringToHash("IsPlay");
    private const string CompletedPref = "Completed";
    private const string SelectButtonSound = "SelectButton";
    private const string MainMenuMusic = "MainMenu";

    public void OpenOptions() {
        if (optionsUI == null || optionsUI.activeSelf)
            return;

        optionsUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void OpenLevels() {
        if (levelsUI == null || levelsUI.activeSelf)
            return;

        levelsUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void CloseSubMenu() {
        if (optionsUI != null && optionsUI.activeSelf) {
            mainUI.SetActive(true);
            optionsUI.SetActive(false);
        }
        else if (levelsUI != null && levelsUI.activeSelf) {
            mainUI.SetActive(true);
            levelsUI.SetActive(false);
        }
    }

    public void ShowLevelButtons() {
        for (var index = 0; index < _completed; index++) {
            levelButtons[index].SetActive(true);
        }
    }

    public void QuitGame() {
        _audioManager.Play(SelectButtonSound);
        levelData.showTutorial = true;
        levelData.isMusicPlaying = false;
        if (Application.isEditor) {
            PlayerPrefs.SetInt(CompletedPref, 1);
        }
        Application.Quit();
    }

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
        _inputManager = new InputManager();

        _inputManager.UI.Cancel.performed += _ => CloseSubMenu();
    }

    private void Start() {
        _completed = PlayerPrefs.GetInt(CompletedPref, 1);
        _audioManager.Play(MainMenuMusic);
    }

    public void LoadScene(string sceneName) {
        _audioManager.Stop(MainMenuMusic);
        _audioManager.Play(SelectButtonSound);

        StartCoroutine(LoadIndexedScene(sceneName));
    }

    private IEnumerator LoadIndexedScene(string sceneName) {
        animator.SetBool(IsPlay, true);
        yield return _wait;
        _audioManager.Play(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }
}