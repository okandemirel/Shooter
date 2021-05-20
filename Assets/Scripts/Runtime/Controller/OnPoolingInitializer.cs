using Runtime.Model;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OnPoolingInitializer : Command
    {
        [Inject] private IPoolModel PoolModel { get; set; }

        public override void Execute()
        {
            PoolModel.PoolSetUp();
        }
    }
}