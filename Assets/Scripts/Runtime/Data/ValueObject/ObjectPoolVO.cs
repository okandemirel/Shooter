using System;
using Runtime.Enums;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Runtime.Data.ValueObject
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