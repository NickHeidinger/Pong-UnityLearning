using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    private bool isPlaying = false;
    private bool isPaused = false;

    void Start()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!isPlaying) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed. isPaused: " + isPaused);
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("StartGame called");
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPlaying = true;
        isPaused = false;
    }

    public void QuitGame()
    {

        Application.Quit();
    }

    private void PauseGame()
    {
        Debug.Log("Game paused");
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        Debug.Log("Game resumed");
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}