using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Profiles;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private EnemyProfile enemyProfile;
    private float health;
    [HideInInspector]
    public Vector3 destination;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = enemyProfile.health;
    }
    void Start()
    {
        navMeshAgent.destination = destination;
    }

    // Update is called once per frame
    void Update()
    {
        
        navMeshAgent.speed = enemyProfile.speed;
        if (health <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Projectile")
        {
            health -= other.GetComponentInParent<Tower>().damage;
            Destroy(other.gameObject);
        }    
    }
}
