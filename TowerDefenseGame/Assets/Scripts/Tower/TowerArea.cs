using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.Events;
using System;
using UI;
using UnityEngine.EventSystems;
public class TowerArea : MonoBehaviour
{
    [SerializeField]
    private UnityEvent[] noTowerFunctions;
    [SerializeField]
    private UnityEvent[] burstTowerFunctions;
    [SerializeField]
    private UnityEvent[] sniperTowerFunctions;
    [SerializeField]
    private UnityEvent[] bomberTowerFunctions;
    [SerializeField]
    private Vector3 towerOffset;
    private Tower currentTower;
    private OnSelectMenuFunctions onSelectMenuFunctions;
    private UIController uIController;
    private Transform colliderTransform;
    private string towerType;
    
    // Start is called before the first frame update
    void Awake()
    {
        towerType = "NoTower";
        uIController = GetComponent<UIController>();
        
        onSelectMenuFunctions = GetComponent<OnSelectMenuFunctions>();
        onSelectMenuFunctions.InitializeFunctions(noTowerFunctions, burstTowerFunctions, sniperTowerFunctions, bomberTowerFunctions);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnEnable() 
    {
        InputManager.onSelectEvent += OnSelect;
    }
    private void OnDisable() 
    {
        
    }
    public void BuildTower(GameObject tower)
    {
        uIController.HideOnSelectMenus();
        if (currentTower == null)
        {
            currentTower = Instantiate(tower,transform).GetComponent<Tower>();
            towerType = currentTower.tag;
            EconomyManager.instance.SpendMoney(100);
        }
        else
        {
            if (tower != currentTower)
            {

            }
        }
    }
    public void OnSelect(Transform _transform)
    {
        uIController.HideOnSelectMenus();
        if (transform == _transform)
        {
            uIController.DisplayOnSelectMenu(towerType);
        } 
        else if (currentTower != null)
        {
            if (currentTower.transform == _transform)
            {
                uIController.DisplayOnSelectMenu(towerType);
            }
        }
    }
    public void IncreaseDamage()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
            tower.damage += tower.towerProfile.damageIncreaseAmount;
        EconomyManager.instance.SpendMoney(30);
    }
    public void DivideFireCooldown()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
            tower.cooldown /= tower.towerProfile.fireCooldownDivisionAmount;
        EconomyManager.instance.SpendMoney(40);
    }
    public void IncreaseRange()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
            tower.range += tower.towerProfile.rangeIncreaseAmount;
        EconomyManager.instance.SpendMoney(80);
    }
    public void DestroyTower()
    {
        Tower tower = GetComponentInChildren<Tower>();
        if (tower != null)
        {
            Destroy(tower.gameObject);
            uIController.HideOnSelectMenus();
            towerType = "NoTower";
            EconomyManager.instance.GainMoney(50);
        }
            
    }
}
