
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefarb;
    [SerializeField] GameObject tallobstaclePrefab;
    [SerializeField] float tallObstacleChance=0.2f;
    void Start()
    {
        groundSpawner=GameObject.FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }


    public void SpawnObstacles()
    {
        GameObject obstacletospawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacletospawn = tallobstaclePrefab;
        }
        int obstacleSpawnerIndex = Random.Range(2,5);
        Transform spawnPoint=transform.GetChild(obstacleSpawnerIndex).transform;

        Instantiate(obstacletospawn, spawnPoint.position, Quaternion.identity, transform);

    }

    public void SpawnCoins()
    {
        int coinstospawn = 5;
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
