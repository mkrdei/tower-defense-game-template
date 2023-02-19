using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Profiles
{
    [CreateAssetMenu(fileName = "OnSelectMenuProfile", menuName = "ScriptableObjects/OnSelectMenu", order = 1)]
    public class OnSelectMenuProfile : ScriptableObject
    {
        public GameObject menuPrefab;
        public GameObject menuItemPrefab;
        public Sprite[] sprites;
    }
}