using System.Collections.Generic;
using Modules.ObjectPooler.Scripts.Runtime.Data.UnityObject;
using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Model;
using Runtime.Views;
using Sirenix.OdinInspector;
using strange.extensions.context.api;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.ObjectPooler.Scripts.Runtime.Model
{
    public class PoolModel : IPoolModel
    {
        [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject contextView { get; set; }

        private CD_Pool _poolSource;
        private GameObject _poolParent;


        #region Post Construct

        [PostConstruct]
        public void OnPostConstruct()
        {
            _poolSource = Resources.Load<CD_Pool>("Data/CD_Pool");

            _poolParent = new GameObject("PoolParent");
            _poolParent.transform.parent = contextView.transform;
        }

        public CD_Pool PoolSource
        {
            get
            {
                if (_poolSource == null)
                    OnPostConstruct();

                return _poolSource;
            }
        }

        #endregion

        #region SetUp

        [ShowInInspector] public Dictionary<PoolType, Queue<GameObject>> PoolableObjectDictionary { get; set; }

        public void PoolSetUp()
        {
            PoolableObjectDictionary = new Dictionary<PoolType, Queue<GameObject>>();

            foreach (var pool in PoolSource.PoolList)
            {
                Queue<GameObject> poolableObjects = new Queue<GameObject>();

                for (int i = 0; i < pool.Value.Amount; i++)
                {
                    if (pool.Key == PoolType.Bullet && pool.Value.PoolObject == null)
                    {
                        pool.Value.PoolObject =
                            Resources.Load<GameObject>("Prefabs/Bullet Prefab"); //Data atanmadıysa diye geçici çözüm
                    }

                    var go = Object.Instantiate(pool.Value.PoolObject, _poolParent.transform, true);
                    go.SetActive(false);
                    pool.Value.Type = pool.Key;
                    switch (pool.Key)
                    {
                        case PoolType.Bullet:
                            go.GetComponent<BulletView>().Vo = (BulletVO) pool.Value.Vo;
                            break;
                        case PoolType.PatlayanBullet:
                            go.GetComponent<BulletView>().Vo = (BulletVO) pool.Value.Vo;
                            break;
                    }


                    poolableObjects.Enqueue(go);
                }

                PoolableObjectDictionary.Add(pool.Key, poolableObjects);
            }
        }

        #endregion

        public GameObject DequeuePoolableGameObject(PoolType type)
        {
            if (!PoolableObjectDictionary.ContainsKey(type))
            {
                Debug.LogError($"Dictionary does not contain this key: {type}...");
                return null;
            }

            var deQueuedPoolObject = PoolableObjectDictionary[type].Dequeue();
            if (deQueuedPoolObject.activeSelf) DequeuePoolableGameObject(type);
            deQueuedPoolObject.SetActive(true);
            return deQueuedPoolObject;
        }

        public void EnqueuePooledGameObject(GameObject poolObject, PoolType type)
        {
            poolObject.transform.parent = _poolParent.transform;
            poolObject.transform.localPosition = Vector3.zero;
            poolObject.transform.localEulerAngles = Vector3.zero;

            poolObject.gameObject.SetActive(false);

            PoolableObjectDictionary[type].Enqueue(poolObject);
        }
    }
}