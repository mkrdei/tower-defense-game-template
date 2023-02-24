using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Vector3 destination;
        private Transform baseEnd;
        // Start is called before the first frame update
        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
    }
}