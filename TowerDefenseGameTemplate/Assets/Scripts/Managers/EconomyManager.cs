using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Managers
{
    public class EconomyManager : MonoBehaviour
    {
        public static EconomyManager instance;
        [SerializeField]
        private Transform moneyTextTransform;
        private TextMeshProUGUI moneyTextUI;
        private float money = 1000;
        void Awake()
        {
            if (instance == null)
                    instance = this;
                else if (instance != this)
                    Destroy(instance);

            moneyTextUI = moneyTextTransform.GetComponent<TextMeshProUGUI>();
            moneyTextUI.text = "Money: " + money;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void SpendMoney(float amount)
        {
            money -= amount;
            moneyTextUI.text = "Money: " + money;
        }
        public void GainMoney(float amount)
        {
            money += amount;
            moneyTextUI.text = "Money: " + money;
        }
    }
}
