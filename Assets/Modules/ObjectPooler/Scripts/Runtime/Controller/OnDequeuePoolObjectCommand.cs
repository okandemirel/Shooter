using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Modules.ObjectPooler.Scripts.Runtime.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Controller
{
    public class OnDequeuePoolObjectCommand : Command
    {
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public Vector3 SpawnPosition { get; set; }

        [Inject] public PoolType PoolType { get; set; }

        public override void Execute()
        {
            var bulletObject = PoolModel.DequeuePoolableGameObject(PoolType);
            bulletObject.transform.localPosition = SpawnPosition;
            bulletObject.transform.localEulerAngles = new Vector3(0, 90, 90);
        }
    }
}