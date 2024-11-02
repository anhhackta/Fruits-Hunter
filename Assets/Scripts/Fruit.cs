using UnityEngine;

public class Fruit : MonoBehaviour
{
    public enum FruitType { Yellow, Red, Orange, Green, Blue, Black }
    public FruitType fruitType;

    private static readonly int[] points = { 10, 20, 30, 40, 50, -100 };

    public int pointValue
    {
        get { return GetPoint(); }
    }

    public int GetPoint()
    {
        return points[(int)fruitType];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            // Chỉ trừ máu nếu điểm là dương
            if (pointValue > 0)
            {
                AudioManager.Instance.PlayGroundHitSound();
                GameManager.Instance.LoseHealth();
            }
            // Trả trái cây về pool
            FruitPool.Instance.ReturnFruit(gameObject);
        }
    }
}
