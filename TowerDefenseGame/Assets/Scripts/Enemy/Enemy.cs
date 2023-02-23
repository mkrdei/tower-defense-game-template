using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Profiles;
using Managers;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public EnemyProfile enemyProfile;
    private float health;
    private float speed;
    [HideInInspector]
    public Vector3 destination;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = enemyProfile.health;
        speed = enemyProfile.speed;
    }
    void Start()
    {
        navMeshAgent.destination = destination;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.speed = speed;
        if (health <= 0)
        {
            if (enemyProfile.name == "Enemy1")
                EconomyManager.instance.GainMoney(50);
            else if (enemyProfile.name == "Enemy2")
                EconomyManager.instance.GainMoney(100);
            Destroy(gameObject);
        }   
    }
    private void OnEnable() 
    {
        GameManager.gameOverEvent += Stop;    
    }
    private void OnDisable() 
    {
        GameManager.gameOverEvent -= Stop;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Projectile")
        {
            health -= other.GetComponentInParent<Tower>().damage;
            Destroy(other.gameObject);
        }    
    }
    private void Stop()
    {
        speed = 0;
    }
}
