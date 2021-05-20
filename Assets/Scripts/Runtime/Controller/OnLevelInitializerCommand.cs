using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OnLevelInitializerCommand : Command
    {
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
            GameSignals.onLevelInitialize.Dispatch();
        }
    }
}