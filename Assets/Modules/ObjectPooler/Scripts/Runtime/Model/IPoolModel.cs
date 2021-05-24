using System.Collections.Generic;
using Modules.ObjectPooler.Scripts.Runtime.Data.UnityObject;
using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Runtime.Data.UnityObject;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Model
{
    [ShowInInspector]
    public interface IPoolModel
    {
        CD_Pool PoolSource { get; }

        GameObject DequeuePoolableGameObject(PoolType Type);
        Dictionary<PoolType, Queue<GameObject>> PoolableObjectDictionary { get; set; }

        void PoolSetUp();
        void EnqueuePooledGameObject(GameObject poolObject, PoolType Type);
    }
}