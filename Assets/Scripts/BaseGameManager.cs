using UnityEngine;

public class BaseGameManager : Singleton<BaseGameManager>
{
    public int maxLives = 3;
    public int currentLives;
    public int score;
    public bool isGameActive;

    public virtual void StartGame()
    {
        currentLives = maxLives;
        score = 0;
        isGameActive = true;
        UIManager.Instance.UpdateLives(currentLives);
        UIManager.Instance.UpdateScore(score);
    }

    public virtual void EndGame()
    {
        isGameActive = false;
        UIManager.Instance.ShowGameOverPanel(score);
    }

    public void ReduceLife()
    {
        currentLives--;
        UIManager.Instance.UpdateLives(currentLives);
        if (currentLives <= 0)
        {
            EndGame();
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        if (score < 0)
        {
            ReduceLife();
            score = 0; // Reset score to 0 if negative
        }
        UIManager.Instance.UpdateScore(score);
    }
}
