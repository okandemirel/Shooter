using Runtime.Key;
using Runtime.Model;
using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OnGetPlayerDataCommand : Command
    {
        [Inject] public IPlayerModel PlayerModel { get; set; }

        [Inject] public GameSignals GameSignals { get; set; }

        public LevelStartPlayerDataHolderParams LevelStartPlayerDataHolderParams { get; set; }


        public override void Execute()
        {
            Retain();

            GetPlayerData();

            GameSignals.onPlayerDataInitialize.Dispatch(LevelStartPlayerDataHolderParams);
            Release();
        }

        private void GetPlayerData()
        {
            LevelStartPlayerDataHolderParams = PlayerModel.LoadPlayerData();
        }
    }
}