using UnityEngine;
using System;
using UnityEngine.EventSystems;
namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<Transform> onSelectEvent;
        public static event Action<Transform> onHoldEvent;
        private Transform raycastedObjectTransform;
        private float raycastDuration;
        [SerializeField]
        private float holdDuration;
        private int raycastLayerMask;
        
        // Start is called before the first frame update
        void Awake()
        {
            //raycastLayerMask = LayerMask.GetMask("Machine", "UI");
        }

        // Update is called once per frame
        void Update()
        {
            SetMouseInputEvents();
        }
        private void SetMouseInputEvents()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Interactable")) && !EventSystem.current.IsPointerOverGameObject()) 
                {
                    if (raycastedObjectTransform == hit.transform)
                    {
                        raycastDuration += Time.deltaTime;    
                    }
                    else
                    {
                        raycastedObjectTransform = hit.transform;
                        Debug.Log("Selected " + raycastedObjectTransform.name);
                        onSelectEvent?.Invoke(raycastedObjectTransform);
                    }
                    if (raycastDuration == holdDuration)
                    {
                        Debug.Log("Hold " + raycastedObjectTransform.name);
                        onHoldEvent?.Invoke(raycastedObjectTransform);
                    }
                }
            }
            else
            {
                raycastDuration = 0;
                raycastedObjectTransform = null;
            }
        }
    }
}