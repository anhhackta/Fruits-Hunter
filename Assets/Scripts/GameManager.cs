using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0; // Tổng điểm
    public int currentScore = 0; // Điểm hiện tại
    public int health = 3;
    public Text scoreText;
    public GameObject[] hearts; // Hình trái tim để hiển thị mạng
    public GameObject gameOverUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        // Cập nhật điểm số trên UI
        scoreText.text = "Score: " + score;
        UpdateHealthDisplay();

        // Kiểm tra nếu hết mạng
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        currentScore = score; // Cập nhật currentScore mỗi khi cộng điểm
    }

    public void LoseHealth()
    {
        health--;
    }

    void UpdateHealthDisplay()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health); // Hiển thị trái tim dựa trên mạng còn lại
        }
    }

    void GameOver()
    {
        AudioManager.Instance.PlayGameOverSound(); // Phát âm thanh Game Over
         gameOverUI.SetActive(true); // Kích hoạt Game Over UI
        GameOverMenu menu = FindObjectOfType<GameOverMenu>();
        menu.ShowGameOver(currentScore);
        Time.timeScale = 0f;
    }
}
