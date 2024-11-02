using UnityEngine;
using System.Collections.Generic;

public class FruitPool : MonoBehaviour
{
    public static FruitPool Instance;
    public GameObject[] fruitPrefabs; // Danh sách các loại trái cây
    public int initialPoolSize = 5; // Số lượng ban đầu của mỗi loại trái cây trong pool
    private Dictionary<string, List<GameObject>> fruitPools;

     void Awake()
    {
        // Đảm bảo chỉ có một instance duy nhất
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại đối tượng khi chuyển cảnh
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        fruitPools = new Dictionary<string, List<GameObject>>();
        
        foreach (var prefab in fruitPrefabs)
        {
            string key = prefab.name;
            fruitPools[key] = new List<GameObject>();

            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject fruit = Instantiate(prefab);
                fruit.SetActive(false);
                fruitPools[key].Add(fruit);
            }
        }
    }

    public GameObject GetFruit(string fruitType)
    {
    if (fruitPools.ContainsKey(fruitType))
    {
        foreach (var fruit in fruitPools[fruitType])
        {
            if (fruit != null && !fruit.activeInHierarchy) // Kiểm tra null trước
            {
                fruit.SetActive(true);
                return fruit;
            }
        }

        // Nếu không có trái cây nào rảnh, tạo mới nếu cần mở rộng pool
        GameObject newFruit = Instantiate(fruitPrefabs[GetPrefabIndex(fruitType)]);
        newFruit.SetActive(true);
        fruitPools[fruitType].Add(newFruit);
        Debug.Log($"Created new fruit: {fruitType}");
        return newFruit;
    }
    
    Debug.LogError($"Fruit type not found: {fruitType}");
    return null; // Không tìm thấy loại trái cây yêu cầu
    }

    public void ReturnFruit(GameObject fruit)
    {
        Debug.Log($"Returning fruit: {fruit.name}");
        fruit.SetActive(false);
    }

    private int GetPrefabIndex(string fruitType)
    {
        for (int i = 0; i < fruitPrefabs.Length; i++)
        {
            if (fruitPrefabs[i].name == fruitType)
                return i;
        }
        return 0; // Mặc định trả về chỉ số đầu tiên nếu không tìm thấy
    }
}
