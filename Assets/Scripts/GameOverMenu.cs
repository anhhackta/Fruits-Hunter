using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreText; // Text để hiển thị điểm
    public GameObject gameOverPanel; // Panel Game Over

    // Gọi hàm này để hiển thị Game Over
    public void ShowGameOver(int currentScore)
    {
        gameOverPanel.SetActive(true); // Hiện Game Over Panel
        scoreText.text = "Score: " + currentScore; // Cập nhật điểm
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Tải lại scene hiện tại
    }

    public void Home()
    {
        SceneManager.LoadScene("MainScene"); // Tải scene chính
    }
}