using Runtime.Signals;
using Runtime.Views;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller
{
    public class OnSetCinemachineTargetCommand : Command
    {
        [Inject] public GameSignals GameSignals { get; set; }

        public override void Execute()
        {
            GameSignals.onSetCinemachineTarget.Dispatch(Object.FindObjectOfType<PlayerView>().gameObject);
        }
    }
}