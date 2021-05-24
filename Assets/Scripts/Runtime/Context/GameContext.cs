using Modules.Core.Abstract.Model;
using Modules.Core.Concrete.Model;
using Rich.Base.Runtime.Concrete.Context;
using Rich.Base.Runtime.Extensions;
using Runtime.Concrete.Injectable.Controller;
using Runtime.Controller;
using Runtime.Mediators;
using Runtime.Model;
using Runtime.Signals;
using Runtime.Utility;
using Runtime.Views;
using UnityEngine;

namespace Runtime.Context
{
    public class GameContext : RichMVCContext
    {
        private GameSignals _gameSignals;
        private UISignals _uiSignals;
        private InputSignals _inputSignals;
        private SRSignals _srSignals;

        protected override void mapBindings()
        {
            base.mapBindings();


            _uiSignals = injectionBinder.BindCrossContextSingletonSafely<UISignals>();
            _gameSignals = injectionBinder.BindCrossContextSingletonSafely<GameSignals>();
            _inputSignals = injectionBinder.BindCrossContextSingletonSafely<InputSignals>();
            _srSignals = injectionBinder.BindCrossContextSingletonSafely<SRSignals>();


            //Injection Bindings
            injectionBinder.Bind<IGameModel>().To<GameModel>().CrossContext().ToSingleton();
            injectionBinder.Bind<IInputModel>().To<InputModel>().CrossContext().ToSingleton();
            injectionBinder.Bind<IPlayerModel>().To<PlayerModel>().CrossContext().ToSingleton();
            injectionBinder.Bind<ProjectSROptions>().ToSingleton().CrossContext();


            //Mediation Bindings
            mediationBinder.BindView<PlayerView>().ToMediator<PlayerMediator>();
            mediationBinder.BindView<BulletView>().ToMediator<BulletMediator>();
            mediationBinder.BindView<InputView>().ToMediator<InputMediator>();
            mediationBinder.BindView<CameraView>().ToMediator<CameraMediator>();
            mediationBinder.BindView<ScoreTableView>().ToMediator<ScoreTableMediator>();

            //Command Bindings
            

            //Level Behaviour
            commandBinder.Bind(_gameSignals.onLevelInitialize).InSequence()
                .To<OnGetInputDataCommand>()
                .To<OnGetPlayerDataCommand>()
                .To<OnSetCinemachineTargetCommand>();

            commandBinder.Bind(_gameSignals.onLevelStart).To<OnActivateTouchCommand>();


            //Game Initalizer    
            commandBinder.Bind(_gameSignals.onGameInitialize).InSequence()
                .To<OnSRDebuggerInitializerFixCommand>()
                .To<OnSROptionsInjectionCommand>()
                .To<OnLevelInitializerCommand>();
        }

        public override void Launch()
        {
            base.Launch();
            Application.targetFrameRate = 60;
            _gameSignals.onGameInitialize.Dispatch();
        }
    }
}