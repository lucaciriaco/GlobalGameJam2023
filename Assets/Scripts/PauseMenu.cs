using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;
    [SerializeField] GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenuController();
    }

    public void PauseMenuController()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.gameObject.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.gameObject.SetActive(false);
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
