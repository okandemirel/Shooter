using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Signals;
using Runtime.Views;
using UnityEngine;

namespace Runtime.Mediators
{
    public class CameraMediator : MediatorLite
    {
        [Inject] public CameraView view { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            GameSignals.onSetCinemachineTarget.AddListener(OnSetCinemachineTarget);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GameSignals.onSetCinemachineTarget.RemoveListener(OnSetCinemachineTarget);
        }

        private void OnSetCinemachineTarget(GameObject target)
        {
            view.SetCameraTarget(target);
        }
    }
}