using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Managers;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform baseDestination;
    [SerializeField]
    float enemySpawnInterval;
    float enemySpawnTimestamp;
    [SerializeField]
    private List<Waves> waves;
    private int enemyGroupIndex;
    private bool spawning;
    private int waveNumber;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
            if (enemyGroupIndex < waves[waveNumber].enemyGroups.Count)
                if (Time.time >= enemySpawnTimestamp)
                    {
                        enemySpawnTimestamp = Time.time + enemySpawnInterval;
                        SpawnWaveEnemyGroups();
                    }
    }
    private void OnEnable() 
    {
        WaveManager.waveStartedEvent += StartSpawning;
    }
    private void OnDisable() 
    {
        
    }
    
    private void SpawnWaveEnemyGroups()
    {
        for (int i = 0; i < waves[waveNumber].enemyGroups[enemyGroupIndex].amount; i++)
        {
            GameObject enemy = Instantiate(waves[waveNumber].enemyGroups[enemyGroupIndex].enemyPrefab, transform);
            enemy.GetComponent<Enemy>().destination = baseDestination.position;
        }
        enemyGroupIndex++;
    }
    private void StartSpawning(int _waveNumber)
    {
        waveNumber = _waveNumber;
        enemyGroupIndex = 0;
        spawning = true;
    }
    [Serializable]
    public class EnemyGroups
    {
        public GameObject enemyPrefab;
        public int amount;
    }
    [Serializable]
    public class Waves
    {
        [HideInInspector]
        public string name = "Wave";
        public List<EnemyGroups> enemyGroups;
    }

    
}

