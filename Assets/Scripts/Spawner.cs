using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public Vector2 SpawnXRange;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCatcher), 0, 2.0f);
        InvokeRepeating(nameof(SpawnEvader), 1, 3.0f);
    }

    private void SpawnCatcher()
    {
        SpawnEnemy(EnemyType.Catcher);
    }

    private void SpawnEvader()
    {
        SpawnEnemy(EnemyType.Evader);
    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        Vector3 spawnPostion = new Vector3(
                    Random.Range(SpawnXRange[0], SpawnXRange[1]),
                    enemyPrefab.transform.position.y,
                    enemyPrefab.transform.position.z);

        if (enemyType == EnemyType.Evader)
        {
            Instantiate(enemyPrefab, spawnPostion, enemyPrefab.transform.rotation);
        }
        else
        {
            Instantiate(enemy2Prefab, spawnPostion, enemy2Prefab.transform.rotation);

        }

    }
}
