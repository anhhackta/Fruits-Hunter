using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public FruitPool objectPool;
    public GameObject spawnArea; 
    public float spawnInterval = 1f;
    private int totalPoints = 0; // Biến để lưu tổng điểm

    void Start()
    {
    if (FruitPool.Instance == null)
    {
        Debug.LogError("FruitPool instance is null. Make sure it is initialized.");
        return;
    }
    objectPool = FruitPool.Instance; // Gán instance cho objectPool
    InvokeRepeating("SpawnFruit", 0f, spawnInterval);
    }

    void SpawnFruit()
    {
        float randomValue = Random.Range(0f, 1f);
        string selectedFruitName;
        if (randomValue < 0.3f)       
            selectedFruitName = "Yellow";
        else if (randomValue < 0.55f) 
            selectedFruitName = "Red";
        else if (randomValue < 0.75f) 
            selectedFruitName = "Orange";
        else if (randomValue < 0.85f) 
            selectedFruitName = "Green";
        else if (randomValue < 0.95f) 
            selectedFruitName = "Black";
        else                          
            selectedFruitName = "Blue";

        GameObject fruit = objectPool.GetFruit(selectedFruitName);
        if (fruit != null)
        {
            // Tính toán vị trí ngẫu nhiên trên spawnArea
            float spawnX = Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2, spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2);
            float spawnY = spawnArea.transform.position.y + spawnArea.transform.localScale.y / 2;

            fruit.transform.position = new Vector3(spawnX, spawnY, 0);
            fruit.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        }
    }

     public void AddPoints(Fruit fruit)
    {
        totalPoints += fruit.GetPoint();
        Debug.Log("Total Points: " + totalPoints);
    }
}
