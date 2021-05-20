using Runtime.Data.ValueObject;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Input", menuName = "Shooter/CD_Input", order = 0)]
    public class CD_Input : SerializedScriptableObject
    {
        public InputVO InputData;
    }
}