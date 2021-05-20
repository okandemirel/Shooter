using Runtime.Data.ValueObject;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "Shooter/CD_Player", order = 0)]
    public class CD_Player : SerializedScriptableObject
    {
        public PlayerVO playerData;
    }
}