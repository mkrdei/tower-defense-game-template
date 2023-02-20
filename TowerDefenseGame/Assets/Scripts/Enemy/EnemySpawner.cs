using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform baseDestination;
    [SerializeField]
    float enemySpawnInterval;
    float enemySpawnTimestamp;
    [SerializeField]
    private List<SpawnedEnemyData> spawnedEnemyDatas;
    private int spawnIndex;
    // Start is called before the first frame update
    void Awake()
    {
        spawnIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < spawnedEnemyDatas.Count)
            if (Time.time >= enemySpawnTimestamp)
                {
                    enemySpawnTimestamp = Time.time + enemySpawnInterval;
                    SpawnEnemy(spawnedEnemyDatas[spawnIndex]);
                    spawnIndex++;
                }
    }
    
    private void SpawnEnemy(SpawnedEnemyData spawnedEnemyData)
    {
        for (int i = 0; i < spawnedEnemyData.amount; i++)
        {
            GameObject enemy = Instantiate(spawnedEnemyData.enemyPrefab, transform);
            enemy.GetComponent<Enemy>().destination = baseDestination.position;
        }
    }
    [Serializable]
    public class SpawnedEnemyData
    {
        public GameObject enemyPrefab;
        public int amount;
    }
}

