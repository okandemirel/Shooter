using Runtime.Key;
using Runtime.Model;
using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OnGetInputDataCommand : Command
    {
        [Inject] public IInputModel InputModel { get; set; }

        [Inject] public GameSignals GameSignals { get; set; }

        public LevelStartInputDataHolderParam LevelStartInputDataHolderParam { get; set; }


        public override void Execute()
        {
            Retain();

            GetInputData();

            GameSignals.onInputDataInitialize.Dispatch(LevelStartInputDataHolderParam);
            Release();
        }

        private void GetInputData()
        {
            LevelStartInputDataHolderParam = InputModel.LoadInputData();
        }
    }
}