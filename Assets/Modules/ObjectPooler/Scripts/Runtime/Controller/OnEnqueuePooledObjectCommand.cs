using Modules.ObjectPooler.Scripts.Runtime.Key;
using Modules.ObjectPooler.Scripts.Runtime.Model;
using strange.extensions.command.impl;

namespace Modules.ObjectPooler.Scripts.Runtime.Controller
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