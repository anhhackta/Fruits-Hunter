using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject targetObject; 
    public GameObject fruitPrefab; 
    public float moveSpeed = 2f; 
    public float attackInterval = 3f; 
    public float spawnAngleOffset = 20f; 

    private bool isAttacking = false;
    private Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        StartCoroutine(Attack()); // Bắt đầu tấn công ngay lập tức
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (transform.position != targetObject.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
        }
        else if (!isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        for (int i = 0; i < 2; i++)
        {
            SpawnFruits();
            yield return new WaitForSeconds(attackInterval);
        }

        yield return StartCoroutine(MoveToStart());
        isAttacking = false;
    }

    private void SpawnFruits()
    {
        for (int i = -1; i <= 1; i++)
        {
            float angle = i * spawnAngleOffset; 
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(fruitPrefab, transform.position, rotation);
        }
    }

    private IEnumerator MoveToStart()
    {
        yield return new WaitForSeconds(90f); 
    }
}
