using System.Collections.Generic;
using Runtime.Data.UnityObject;
using Runtime.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Model
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