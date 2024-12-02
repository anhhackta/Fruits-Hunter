using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Canvas UIManagerCanvas;
    public List<BasePanel> basePanelPrefabList;
    private Dictionary<Type, BasePanel> panelMap = new Dictionary<Type, BasePanel>();

    void Awake()
    {
        foreach (var panelPrefab in basePanelPrefabList)
        {
            if (panelPrefab)
            {
                var panel = Instantiate(panelPrefab, UIManagerCanvas.transform, false);
                panelMap.Add(panel.GetType(), panel);
                panel.HidePanel();
            }
        }
    }

    public BasePanel GetPanel<T>() where T : BasePanel
    {
        return panelMap[typeof(T)];
    }

    public void ShowPanel<T>() where T : BasePanel
    {
        panelMap[typeof(T)].ShowPanel();
    }

    public void HidePanel<T>() where T : BasePanel
    {
        panelMap[typeof(T)].HidePanel();
    }

    public void TogglePanel<T>() where T : BasePanel
    {
        panelMap[typeof(T)].TogglePanel();
    }

    public void HideAllPanels()
    {
        foreach (var panel in panelMap)
        {
            panel.Value.HidePanel();
        }
    }

    public void ShowGameOverPanel(int finalScore)
    {
        var gameOverPanel = GetPanel<GameOverPanel>() as GameOverPanel;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetFinalScore(finalScore);
            gameOverPanel.ShowHighScores(ScoreManager.Instance.highScores);
            ShowPanel<GameOverPanel>();
        }
    }

    public void UpdateLives(int lives)
    {
        // Cập nhật giao diện người dùng với số mạng hiện tại
        // Ví dụ: livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int score)
    {
        // Cập nhật giao diện người dùng với điểm số hiện tại
        // Ví dụ: scoreText.text = "Score: " + score;
    }
}