using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject mainUI;
    public GameObject optionsUI;

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
        _audioManager.Play("Level0");
    }

    public void LoadGame() {
        _audioManager.Play("Menu");
        _audioManager.Stop("MusicMenu");
        StartCoroutine(LoadNextScene());
    }


    private IEnumerator LoadNextScene() {
        animator.SetBool(IsPlay, true);
        yield return _wait;
        _audioManager.Play("Level1");
        SceneManager.LoadScene("Map 1");
    }

    private void OnEnable() {
        _inputManager.Enable();
    }

    private void OnDisable() {
        _inputManager.Disable();
    }
}