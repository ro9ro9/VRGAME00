using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameTimer gameTimer;

    private bool isPaused = false;

    void Start()
    {
        pauseUI.SetActive(false); // Ω√¿€ Ω√ ¿œΩ√¡§¡ˆ UI º˚±Ë
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) PauseGame();
            else ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameTimer.StopTimer();
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameTimer.StartTimer();
    }

    public void GoToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}
