using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Key;
using Runtime.Signals;
using Runtime.Views;
using UnityEngine;

namespace Runtime.Mediators
{
    public class PlayerMediator : MediatorLite
    {
        [Inject] public PlayerView view { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }
        [Inject] public InputSignals InputSignals { get; set; }


        public override void OnRegister()
        {
            base.OnRegister();

            InputSignals.onMovementInputTaken.AddListener(OnInputTaken);
            InputSignals.onRotationInputTaken.AddListener(OnRotationInputTaken);

            GameSignals.onPlayerDataInitialize.AddListener(OnPlayerDataInitialize);
            GameSignals.onTriggerDequeuePoolableObject.AddListener(OnTriggerDequeuePoolableObject);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            InputSignals.onMovementInputTaken.RemoveListener(OnInputTaken);
            InputSignals.onRotationInputTaken.RemoveListener(OnRotationInputTaken);

            GameSignals.onPlayerDataInitialize.RemoveListener(OnPlayerDataInitialize);
            GameSignals.onTriggerDequeuePoolableObject.RemoveListener(OnTriggerDequeuePoolableObject);
        }


        private void OnPlayerDataInitialize(LevelStartPlayerDataHolderParams playerData)
        {
            view.SetPlayerVo(playerData);
        }

        private void OnInputTaken(MovementInputParams movementInputParams)
        {
            view.UpdateInputPos(movementInputParams.HorizontalValue, movementInputParams.VerticalValue,
                movementInputParams.MovementSpeed);
        }

        private void OnTriggerDequeuePoolableObject()
        {
            //Shotgun type firing will be added here
            var bulletCount = Random.Range(1, view.Vo.ShotgunBulletCount);
            for (int i = 0; i < bulletCount; i++)
            {
                GameSignals.onDequeuePoolObject.Dispatch(view.GunObject.position);
            }

            GameSignals.onBulletFired.Dispatch(bulletCount);
        }

        private void OnRotationInputTaken(RotationInputParams rotationValues)
        {
            view.SetRotation(rotationValues.TurnRotation, rotationValues.TurnSpeed);
        }
    }
}