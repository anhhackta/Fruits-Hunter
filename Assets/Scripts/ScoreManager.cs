using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : Singleton<ScoreManager>
{
    public int currentScore;
    public List<int> highScores = new List<int>();

    private const int MaxHighScores = 10;

    void Start()
    {
        LoadHighScores();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        if (currentScore > highScores[highScores.Count - 1])
        {
            highScores.Add(currentScore);
            highScores.Sort((a, b) => b.CompareTo(a)); // Sắp xếp giảm dần
            if (highScores.Count > MaxHighScores)
            {
                highScores.RemoveAt(highScores.Count - 1); // Giữ lại 10 điểm cao nhất
            }
            SaveHighScores();
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }
        PlayerPrefs.SetInt("HighScoreCount", highScores.Count);
        PlayerPrefs.Save();
    }

    private void LoadHighScores()
    {
        highScores.Clear();
        int count = PlayerPrefs.GetInt("HighScoreCount", 0);
        for (int i = 0; i < count; i++)
        {
            highScores.Add(PlayerPrefs.GetInt("HighScore" + i, 0));
        }
    }
}