using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public Transform target {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            target = other.transform;
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (target != null && target == other.transform)
            target = null;
    }
}
