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
            baseEnd = GameObject.Find("BaseEnd").transform;
            
        }
        void Start()
        {
            navMeshAgent.destination = baseEnd.position;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
    }
}