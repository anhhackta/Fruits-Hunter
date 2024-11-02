using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            Fruit fruit = collision.GetComponent<Fruit>();
            if (fruit != null)
            {
                int points = fruit.pointValue;
                // Kiểm tra điểm hiện tại trước khi cộng
                if (points < 0 && GameManager.Instance.score <= 0 || points < 0 && GameManager.Instance.currentScore < 0)
                {
                    GameManager.Instance.LoseHealth(); // Trừ 1 tim nếu điểm âm
                    AudioManager.Instance.PlayFruitLoseSound();
                }     
                else if (points >= 0 || (points < 0 && GameManager.Instance.score >= 0))
                {
                    GameManager.Instance.AddScore(points); // Cộng điểm
                    AudioManager.Instance.PlayFruitCollectSound();
                }
                // Trả trái cây về pool
                FruitPool.Instance.ReturnFruit(collision.gameObject);
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            GameManager.Instance.LoseHealth();
            AudioManager.Instance.PlayGroundHitSound();
            Destroy(collision.gameObject);
        }
    }
}
