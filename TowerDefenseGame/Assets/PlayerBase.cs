using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Profiles;
using TMPro;
using Managers;
public class PlayerBase : MonoBehaviour
{
    private float health = 1000;
    [SerializeField]
    private Transform baseHealthTextTransform;
    private TextMeshProUGUI baseHealthText;
    // Start is called before the first frame update
    void Awake()
    {
        baseHealthText = baseHealthTextTransform.GetComponent<TextMeshProUGUI>();
        baseHealthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            EnemyProfile enemyProfile = other.GetComponent<Enemy>().enemyProfile;
            health -= enemyProfile.health;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                GameManager.instance.GameOver();
                health = 0;
            }
            baseHealthText.text = "Health: " + health.ToString();
        }    
    }
}
