using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject mainUI;
    public GameObject optionsUI;
    private int completed;
    public GameObject[] levelButtons;

    private AudioManager _audioManager;
    private InputManager _inputManager;
    private readonly WaitForSeconds _wait = new(1.45f);
    private static readonly int IsPlay = Animator.StringToHash("IsPlay");

    public void OpenOptions() {
        if (optionsUI.activeSelf)
            return;

        optionsUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void CloseOptions() {
        if (!optionsUI.activeSelf)
            return;

        mainUI.SetActive(true);
        optionsUI.SetActive(false);
    }

    public void ShowLevelButtons()
    {
        for (int i = 0; i < completed; i++)
        {
            levelButtons[i].SetActive(true);
        }
    }

    public void QuitGame() {
        _audioManager.Play("Menu");
        Application.Quit();
    }

    private void Awake() {
        _audioManager = FindObjectOfType<AudioManager>();
        _inputManager = new InputManager();

        _inputManager.UI.Cancel.performed += _ => CloseOptions();
    }

    private void Start() {
        completed = PlayerPrefs.GetInt("Completed", 1);
        _audioManager.Play("Level0");
    }

    public void LoadGame() {
        _audioManager.Play("Menu");
        _audioManager.Stop("MusicMenu");
        StartCoroutine(LoadNextScene());
        // animator.Play("throw");

    }

    public void LoadMap2() {
        _audioManager.Play("Menu");
        _audioManager.Stop("MusicMenu");
        StartCoroutine(Map2());
        // animator.Play("throw");

    }

    public void LoadMap3() {
        _audioManager.Play("Menu");
        _audioManager.Stop("MusicMenu");
        StartCoroutine(Map3());
        // animator.Play("throw");

    }


    private IEnumerator LoadNextScene() {
        animator.SetBool(IsPlay, true);
        yield return _wait;
        _audioManager.Play("Level1");
        SceneManager.LoadScene("Map 1");
    }

    private IEnumerator Map2() {
        animator.SetBool(IsPlay, true);
        yield return _wait;
        _audioManager.Play("Level2");
        SceneManager.LoadScene("Map 2");
    }

    private IEnumerator Map3() {
        animator.SetBool(IsPlay, true);
        yield return _wait;
        _audioManager.Play("Level3");
        SceneManager.LoadScene("Map3");
    }
    

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }

    public void waitBackgroundAnim()
    {
        
        // animator.SetBool(IsPlay, true);
        // animator.SetBool("IsPlay", true);
        // _audioManager.Play("Level1");
        // SceneManager.LoadScene("Map 1");
        // animator.SetBool("IsPlay", true);
    }
}