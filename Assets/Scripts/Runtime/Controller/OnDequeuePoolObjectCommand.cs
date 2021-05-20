using Runtime.Enums;
using Runtime.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller
{
    public class OnDequeuePoolObjectCommand : Command
    {
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public Vector3 SpawnPosition { get; set; }

        public override void Execute()
        {
            var bulletObject = PoolModel.DequeuePoolableGameObject(PoolType.Bullet);
            bulletObject.transform.localPosition = SpawnPosition;
            bulletObject.transform.localEulerAngles = new Vector3(0, 90, 90);
        }
    }
}