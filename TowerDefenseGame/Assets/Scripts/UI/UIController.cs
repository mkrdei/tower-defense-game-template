using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using Profiles;
namespace UI
{

    public class UIController : MonoBehaviour
    {
        private GameObject[] onSelectMenus;
        private GameObject currentOnSelectMenu;
        [SerializeField]
        private Vector3 menuOffset = new Vector3(0,3,0);
        private OnSelectMenuFunctions onSelectMenuFunctions;
        private LayerMask uILayer;
        [SerializeField]
        private OnSelectMenuProfile[] onSelectMenuProfiles;
        void Awake() 
        {   
            onSelectMenuFunctions = GetComponent<OnSelectMenuFunctions>();
            onSelectMenus = new GameObject[onSelectMenuProfiles.Length];
            //onSelectMenuItemSprites = GetComponent<Tower
            
            
            uILayer = LayerMask.GetMask("UI");
        }
        void Start()
        {
            for (int onSelectMenuIndex = 0; onSelectMenuIndex < onSelectMenuProfiles.Length; onSelectMenuIndex++)
            {
                {
                    onSelectMenus[onSelectMenuIndex] = Instantiate(onSelectMenuProfiles[onSelectMenuIndex].menuPrefab);
                    onSelectMenus[onSelectMenuIndex].SetActive(false);
                    onSelectMenus[onSelectMenuIndex].name = onSelectMenuProfiles[onSelectMenuIndex].name;
                    CreateOnSelectMenuItems(onSelectMenuIndex, onSelectMenus[onSelectMenuIndex], onSelectMenuFunctions.functionGroups[onSelectMenuIndex]);
                    onSelectMenus[onSelectMenuIndex].transform.position = transform.position + menuOffset;
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
        }
        private void OnApplicationPause(bool pauseStatus) {
            //if (pauseStatus)
                //HideOnSelectMenu();
        }
        private void OnEnable() 
        {
        }
        private void OnDisable() 
        {
        }
        private void CreateOnSelectMenuItems(int onSelectMenuIndex, GameObject onSelectMenu, UnityEvent[] functions)
        {
            Transform menuItemChildTransform;
            Quaternion _rotation;
            float rotationZ;
            GameObject menuItem;
            Image menuItemImage;
            for (int j = 0; j < functions.Length; j++)
            {
                rotationZ = -360/functions.Length*j;
                
                menuItem = Instantiate(onSelectMenuProfiles[onSelectMenuIndex].menuItemPrefab,onSelectMenu.transform.position,Quaternion.identity,onSelectMenu.transform);
                _rotation = Quaternion.Euler(0,0,rotationZ);
                menuItem.transform.localRotation =  _rotation;
                menuItemChildTransform = menuItem.transform.GetChild(0).GetComponent<Transform>();
                menuItemChildTransform.localRotation = Quaternion.Inverse(_rotation);
                menuItemImage = menuItem.GetComponentInChildren<Image>();
                menuItemImage.sprite = onSelectMenuProfiles[onSelectMenuIndex].sprites[j];
                // We need to initialize "j" to another variable. Otherwise, every parameter passes as a value of the loop limit.
                int index = j;
                menuItem.GetComponentInChildren<Button>().onClick.AddListener(() => MenuItemOnClick(functions, index));
            }
        }
        void MenuItemOnClick(UnityEvent[] functions, int index)
        {
            functions[index].Invoke();
        }
        public void DisplayOnSelectMenu(string menuName)
        {
            Debug.Log(onSelectMenus.Length);
            foreach (GameObject onSelectMenu in onSelectMenus)
                if (onSelectMenu.transform.name == menuName)
                        onSelectMenu.SetActive(true);
        }
        public void HideOnSelectMenu(string menuName)
        {
            foreach (GameObject onSelectMenu in onSelectMenus)
                if (onSelectMenu.transform.name == menuName)
                        onSelectMenu.SetActive(false);
        }
        public void HideOnSelectMenus()
        {
            foreach (GameObject onSelectMenu in onSelectMenus)
                onSelectMenu.SetActive(false);
        }
        /*
        public void DisplayNotificationUI(Sprite _sprite)
        {
            notifyImage.GetComponent<Image>().sprite = _sprite;
            notifyCanvas.gameObject.SetActive(true);
        }*/

    }
}
