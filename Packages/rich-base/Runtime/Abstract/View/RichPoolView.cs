using Rich.Base.Runtime.Abstract.Model;

namespace Rich.Base.Runtime.Abstract.View
{
    public class RichPoolView : RichView
    {
        public override bool isInjectable => true;

        protected override void Awake()
        {
            base.Awake();
        }

        [Inject] public IObjectPoolModel Pool { get; set; }
    }
}