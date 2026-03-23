using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject startButton;
    public GameObject restartButton;

    private bool isPlaying = false;
    private bool isPaused = false;

    void Start()
    {
        restartButton.SetActive(false);
        startButton.SetActive(true);
        ShowMenu();
    }

    void Update()
    {
        if (!isPlaying) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void StartGame()
    {
        isPlaying = true;
        isPaused = false;
        startButton.SetActive(false);
        restartButton.SetActive(true);
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        MenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        isPaused = true;
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ShowMenu()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
