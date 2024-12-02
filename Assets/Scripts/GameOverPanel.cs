using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;

public class GameOverPanel : BasePanel
{
    public Text finalScoreText;
    public Text highScoresText;

    public void SetFinalScore(int score)
    {
        finalScoreText.text = "Final Score: " + score;
    }

    public void ShowHighScores(List<int> highScores)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("High Scores:");
        for (int i = 0; i < highScores.Count; i++)
        {
            sb.AppendLine((i + 1) + ". " + highScores[i]);
        }
        highScoresText.text = sb.ToString();
    }
}