using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public Transform uIRoot;
        public static UIManager instance;

        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(instance);
            uIRoot = new GameObject().transform;
            uIRoot.name = "UIRoot";
        }


    }
}
