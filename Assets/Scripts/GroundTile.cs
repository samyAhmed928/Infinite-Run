
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner=GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacles()
    {
        int obstacleSpawnerIndex = Random.Range(2,5);
        Transform spawnPoint=transform.GetChild(obstacleSpawnerIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }
}
