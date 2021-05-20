using Runtime.Enums;
using Runtime.Key;
using Runtime.Model;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller
{
    public class OnEnqueuePooledObjectCommand : Command
    {
        [Inject] public IPoolModel PoolModel { get; set; }
        [Inject] public OnEnqueuePooledObjectParams PooledObjectParams { get; set; }

        public override void Execute()
        {
            PoolModel.EnqueuePooledGameObject(PooledObjectParams.PooledObject, PooledObjectParams.PooledObjectType);
        }
    }
}