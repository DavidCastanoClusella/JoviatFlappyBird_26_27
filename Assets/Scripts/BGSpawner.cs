using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    public GameObject bgPrefab;

    public Transform spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateNewBackground();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNewBackground()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, spawner.position.y, transform.position.z);
        Instantiate(bgPrefab, spawnPosition, Quaternion.identity);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null || other.gameObject == null) return;
        
        if (other.tag == "BACKGROUND")
        {
            CreateNewBackground();
            
            Destroy(other.gameObject);
        }
    }
}
