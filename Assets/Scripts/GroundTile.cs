
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner=GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnCoins();
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
    public GameObject coinPrefarb;

    void SpawnCoins()
    {
        int coinstospawn = 10;
        for (int i = 0; i < coinstospawn; i++)
        {
           GameObject tmp= Instantiate(coinPrefarb,transform);
            tmp.transform.position = getRandomPointCollidar(GetComponent<Collider>());
        }
    }

    Vector3 getRandomPointCollidar(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x,collider.bounds.max.x),
            Random.Range(collider.bounds.min.y,collider.bounds.max.y),
            Random.Range(collider.bounds.min.z,collider.bounds.max.z)

            );
        if (point!=collider.ClosestPoint(point))
        {
            point = getRandomPointCollidar(collider);
        }
        point.y = 1;
        return point;
    }
}
