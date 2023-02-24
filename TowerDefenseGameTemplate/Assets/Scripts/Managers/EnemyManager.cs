using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager instance;
        [SerializeField]
        private Transform[] enemySpawners; 
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(instance);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public int GetEnemyNumbers()
        {
            int enemyNumbers = 0;
            foreach (Transform enemySpawner in enemySpawners)
                enemyNumbers += enemySpawner.childCount;
            return enemyNumbers;
        }
    }
}
