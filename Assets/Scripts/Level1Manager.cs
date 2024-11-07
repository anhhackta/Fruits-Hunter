using UnityEngine;
using System.Collections;

public class Level1Manager : BaseGameManager
{
    public GameObject[] fruitPrefabs; // Danh sách các prefab trái cây
    public float spawnInterval = 1f; // Khoảng thời gian giữa các lần spawn
    public Transform spawnArea; // Vùng spawn trái cây

    public override void StartGame()
    {
        base.StartGame();
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (isGameActive)
        {
            SpawnFruit();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        GameObject fruit = Instantiate(fruitPrefabs[randomIndex], GetRandomPosition(), Quaternion.identity);
        fruit.tag = "Fruit"; // Gán tag cho trái cây để xử lý va chạm
    }

    private Vector3 GetRandomPosition()
    {
        float xPosition = Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2);
        return new Vector3(xPosition, spawnArea.position.y, 0);
    }
}
