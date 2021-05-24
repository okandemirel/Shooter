using Modules.ObjectPooler.Scripts.Runtime.Enums;
using Modules.ObjectPooler.Scripts.Runtime.Key;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Modules.ObjectPooler.Scripts.Runtime.Signals
{
    public class ObjectPoolingSignals : Signal
    {
        public Signal onObjectPoolingInitialize = new Signal();

        public Signal<PoolType, Vector3> onDequeuePoolObject = new Signal<PoolType, Vector3>();
        public Signal<OnEnqueuePooledObjectParams> onEnqueuePooledObject = new Signal<OnEnqueuePooledObjectParams>();
    }
}