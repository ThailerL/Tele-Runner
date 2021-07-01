using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);

        if (pauseUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }

    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f;
    }
}