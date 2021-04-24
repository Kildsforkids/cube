using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnDelay;

    private float nextTimeToSpawn;
    private int currentEnemiesCount = 0;

    private void Start()
    {
        nextTimeToSpawn = spawnDelay;
    }

    private void Update()
    {
        if (Time.time > nextTimeToSpawn && currentEnemiesCount < maxEnemies)
        {
            Spawn();
            nextTimeToSpawn = Time.time + spawnDelay;
            currentEnemiesCount++;
        }
    }

    public void Spawn()
    {
        var pos = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
