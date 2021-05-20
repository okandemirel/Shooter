using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class InputVO
    {
        [Range(0f, 100f)] public float MovementSpeed;
        [Range(0f, 10f)] public float TurnSpeed;
    }
}