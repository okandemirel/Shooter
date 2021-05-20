using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class PlayerVO
    {
        [Range(1, 10)] public int ShotgunBulletCount;
    }
}