using UnityEngine;
using UnityEngine.UI;

public class ResponsiveUIManager : MonoBehaviour
{
    public RectTransform scoreText;
    public RectTransform pauseButton;
    public RectTransform heart1;
    public RectTransform heart2;
    public RectTransform heart3;
    public RectTransform heartFrame1;
    public RectTransform heartFrame2;
    public RectTransform heartFrame3;
    public RectTransform leftButton;
    public RectTransform rightButton;

    private int lives = 3;

    void Start()
    {
        AdjustUI();
        UpdateHearts();
    }

    void Update()
    {
        AdjustUI();
    }

    void AdjustUI()
    {
        // Adjust Score Text (Top Center)
        scoreText.anchorMin = new Vector2(0.5f, 1f);
        scoreText.anchorMax = new Vector2(0.5f, 1f);
        scoreText.pivot = new Vector2(0.5f, 1f);
        scoreText.anchoredPosition = new Vector2(0, -10); // 10 units from the top

        // Adjust Pause Button (Top Right)
        pauseButton.anchorMin = new Vector2(1f, 1f);
        pauseButton.anchorMax = new Vector2(1f, 1f);
        pauseButton.pivot = new Vector2(1f, 1f);
        pauseButton.anchoredPosition = new Vector2(-10, -10); // 10 units from the top-right corner

        // Adjust Hearts (Top Left)
        heart1.anchorMin = new Vector2(0f, 1f);
        heart1.anchorMax = new Vector2(0f, 1f);
        heart1.pivot = new Vector2(0f, 1f);
        heart1.anchoredPosition = new Vector2(10, -10); // 10 units from the top-left corner

        heart2.anchorMin = new Vector2(0f, 1f);
        heart2.anchorMax = new Vector2(0f, 1f);
        heart2.pivot = new Vector2(0f, 1f);
        heart2.anchoredPosition = new Vector2(50, -10); // 50 units from the top-left corner

        heart3.anchorMin = new Vector2(0f, 1f);
        heart3.anchorMax = new Vector2(0f, 1f);
        heart3.pivot = new Vector2(0f, 1f);
        heart3.anchoredPosition = new Vector2(90, -10); // 90 units from the top-left corner

        // Adjust Heart Frames (Top Left)
        heartFrame1.anchorMin = new Vector2(0f, 1f);
        heartFrame1.anchorMax = new Vector2(0f, 1f);
        heartFrame1.pivot = new Vector2(0f, 1f);
        heartFrame1.anchoredPosition = new Vector2(10, -10); // 10 units from the top-left corner

        heartFrame2.anchorMin = new Vector2(0f, 1f);
        heartFrame2.anchorMax = new Vector2(0f, 1f);
        heartFrame2.pivot = new Vector2(0f, 1f);
        heartFrame2.anchoredPosition = new Vector2(50, -10); // 50 units from the top-left corner

        heartFrame3.anchorMin = new Vector2(0f, 1f);
        heartFrame3.anchorMax = new Vector2(0f, 1f);
        heartFrame3.pivot = new Vector2(0f, 1f);
        heartFrame3.anchoredPosition = new Vector2(90, -10); // 90 units from the top-left corner

        // Adjust Left Button (Bottom Left)
        leftButton.anchorMin = new Vector2(0f, 0f);
        leftButton.anchorMax = new Vector2(0.5f, 0.5f);
        leftButton.pivot = new Vector2(0f, 0f);
        leftButton.anchoredPosition = new Vector2(0, 0);
        leftButton.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);

        // Adjust Right Button (Bottom Right)
        rightButton.anchorMin = new Vector2(0.5f, 0f);
        rightButton.anchorMax = new Vector2(1f, 0.5f);
        rightButton.pivot = new Vector2(1f, 0f);
        rightButton.anchoredPosition = new Vector2(0, 0);
        rightButton.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHearts();
        }
    }

    void UpdateHearts()
    {
        heart1.gameObject.SetActive(lives > 0);
        heart2.gameObject.SetActive(lives > 1);
        heart3.gameObject.SetActive(lives > 2);

        heartFrame1.gameObject.SetActive(true);
        heartFrame2.gameObject.SetActive(true);
        heartFrame3.gameObject.SetActive(true);
    }
}