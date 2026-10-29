using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public Transform spawnTop;
    public Transform spawnBottom;

    public float timeToSpawn = 2.0f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("CreateNewPipe", timeToSpawn, timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateNewPipe()
    {
        
        float randomY = Random.Range(spawnBottom.position.y,  spawnTop.position.y);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PIPE")
        {
            Destroy(other.gameObject);
        }
    }
}
