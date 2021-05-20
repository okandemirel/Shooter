using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class BulletVO : Attribute
    {
        [Range(0, 10)] public int TimeToEnqueue;
        [Range(0, 100)] public int BulletSpeed;
        [Range(0, 10)] public float minDeflection, maxDeflection;
    }
}