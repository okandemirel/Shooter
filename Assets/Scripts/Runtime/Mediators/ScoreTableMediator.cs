using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Signals;

namespace Runtime.Mediators
{
    public class ScoreTableMediator : MediatorLite
    {
        #region Injections

        [Inject] public ScoreTableView view { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        #endregion


        public override void OnRegister()
        {
            base.OnRegister();
            GameSignals.onBulletFired.AddListener(OnBulletFired);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            GameSignals.onBulletFired.RemoveListener(OnBulletFired);
        }

        private void OnBulletFired(int firedBulletCount)
        {
            view.BulletFired(firedBulletCount);
        }
    }
}