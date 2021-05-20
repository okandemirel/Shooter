using Rich.Base.Runtime.Abstract.Function;
using UnityEngine;

namespace Utility
{
    public class BasePoolObject : MonoBehaviour ,IPoolable
    {
        public void OnGetFromPool()
        {
        }

        public void OnReturnFromPool()
        {
        }

        public string PoolKey { get; set; }
    }
}
