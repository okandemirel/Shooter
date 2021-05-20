using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OnActivateTouchCommand : Command
    {
        [Inject] public InputSignals InputSignals { get; set; }

        public override void Execute()
        {
            InputSignals.onEnableTouch.Dispatch();
        }
    }
}