using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using UI;
public class OnSelectMenuFunctions : MonoBehaviour
{
    public UnityEvent[][] functionGroups { get; private set; }
    void Awake() 
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
    }
    public void InitializeFunctions(params UnityEvent[][] functionGroup)
    {
        functionGroups = new UnityEvent[functionGroup.Length][];
        for (int i = 0; i < functionGroup.Length; i++)
        {
            functionGroups[i] = functionGroup[i];
        }
    }
    
}
