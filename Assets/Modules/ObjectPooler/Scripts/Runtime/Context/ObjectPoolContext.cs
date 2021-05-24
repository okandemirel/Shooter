using JetBrains.Annotations;
using Modules.ObjectPooler.Scripts.Runtime.Controller;
using Modules.ObjectPooler.Scripts.Runtime.Model;
using Modules.ObjectPooler.Scripts.Runtime.Signals;
using Rich.Base.Runtime.Concrete.Context;
using Rich.Base.Runtime.Extensions;

namespace Modules.ObjectPooler.Scripts.Runtime.Context
{
    public class ObjectPoolContext : RichMVCContext
    {
        private ObjectPoolingSignals _objectPoolingSignals;

        protected override void mapBindings()
        {
            base.mapBindings();


            _objectPoolingSignals = injectionBinder.BindCrossContextSingletonSafely<ObjectPoolingSignals>();


            injectionBinder.Bind<IPoolModel>().To<PoolModel>().CrossContext().ToSingleton();


            //In-Game
            commandBinder.Bind(_objectPoolingSignals.onDequeuePoolObject).To<OnDequeuePoolObjectCommand>();
            commandBinder.Bind(_objectPoolingSignals.onEnqueuePooledObject).To<OnEnqueuePooledObjectCommand>();

            commandBinder.Bind(_objectPoolingSignals.onObjectPoolingInitialize).To<OnPoolingInitializer>();
        }

        public override void Launch()
        {
            base.Launch();
            _objectPoolingSignals.onObjectPoolingInitialize.Dispatch();
        }
    }
}