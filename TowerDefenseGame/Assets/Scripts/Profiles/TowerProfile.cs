using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Profiles
{
    [CreateAssetMenu(fileName = "TowerProfile", menuName = "ScriptableObjects/Tower", order = 1)]
    public class TowerProfile : ScriptableObject
    {
        [field: SerializeField]
        public float damageIncreaseAmount {get; private set;}
        [field: SerializeField]
        public float projectileSpeedIncreaseAmount {get; private set;}
        [field: SerializeField]
        public float fireCooldownDivisionAmount {get; private set;}
        [field: SerializeField]
        public float rangeIncreaseAmount {get; private set;}
    }
}