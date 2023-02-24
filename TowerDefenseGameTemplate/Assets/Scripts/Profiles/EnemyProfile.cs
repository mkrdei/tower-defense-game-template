using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Profiles
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
    public class EnemyProfile : ScriptableObject
    {
        public float health = 100;
        public float speed = 5;
    }
}
