using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; 

    void Start()
    
    {
        InvokeRepeating("SpawnObject", 0f, 2f);
    }

    void SpawnObject()  
    {
        var bounds = GetComponent<BoxCollider2D>().bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        
    }
}