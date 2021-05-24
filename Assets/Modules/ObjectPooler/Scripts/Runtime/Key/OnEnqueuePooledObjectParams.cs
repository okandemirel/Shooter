using Modules.ObjectPooler.Scripts.Runtime.Enums;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Key
{
    public struct OnEnqueuePooledObjectParams
    {
        public GameObject PooledObject;
        public PoolType PooledObjectType;
    }
}