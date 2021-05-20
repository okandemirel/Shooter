using System.Collections.Generic;
using Runtime.Data.ValueObject;
using Runtime.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Pool", menuName = "Shooter/CD_Pool", order = 0)]
    public class CD_Pool : SerializedScriptableObject
    {
        public Dictionary<PoolType, ObjectPoolVO> PoolList = new Dictionary<PoolType, ObjectPoolVO>();
    }
}