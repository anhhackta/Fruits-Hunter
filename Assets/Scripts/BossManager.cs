using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject bossPrefab; 
    public Transform spawnPoint;

    private GameObject currentBoss;

    private void Start()
    {
        SpawnBoss();
    }

    public void SpawnBoss()
    {
        if (currentBoss != null)
        {
            Destroy(currentBoss);
        }

        currentBoss = Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity); 
    }

    public void DespawnBoss()
    {
        if (currentBoss != null)
        {
            Destroy(currentBoss);
            currentBoss = null;
        }
    }
}
