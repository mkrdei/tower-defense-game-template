using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
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
