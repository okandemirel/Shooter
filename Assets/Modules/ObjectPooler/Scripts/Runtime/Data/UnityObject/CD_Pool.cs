using System.Collections.Generic;
using Modules.ObjectPooler.Scripts.Runtime.Data.ValueObject;
using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Runtime.Data.ValueObject;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Pool", menuName = "Rich Modules/CD_Pool", order = 0)]
    public class CD_Pool : SerializedScriptableObject
    {
        public Dictionary<PoolType, ObjectPoolVO> PoolList = new Dictionary<PoolType, ObjectPoolVO>();
    }
}