using System;
using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Data.ValueObject
{
    [Serializable]
    [HideReferenceObjectPicker]
    public class ObjectPoolVO
    {
        public GameObject PoolObject;
        public int Amount;
        public Attribute Vo;

        [HideInInspector] public PoolType Type;
    }
}