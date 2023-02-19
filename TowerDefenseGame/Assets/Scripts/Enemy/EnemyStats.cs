using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float speed = 5;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
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
