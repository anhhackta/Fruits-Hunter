using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuUI;

    void Start()
    {
        // Khởi tạo menu tạm dừng từ prefab
        if (pauseMenuPrefab != null)
        {
            pauseMenuUI = Instantiate(pauseMenuPrefab);
            pauseMenuUI.SetActive(false);
        }
    }

    public void OpenPauseMenu()
    {
        if (Time.timeScale == 0)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void Settings()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }
}
