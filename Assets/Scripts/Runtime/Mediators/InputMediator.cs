using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Key;
using Runtime.Signals;
using Runtime.Views;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Mediators
{
    public class InputMediator : MediatorLite
    {
        #region Injections

        [Inject] [ShowInInspector] public InputView view { get; set; }

        [Inject] public InputSignals InputSignals { get; set; }
        [Inject] public GameSignals GameSignals { get; set; }

        #endregion

        public override void OnRegister()
        {
            base.OnRegister();

            view.onMovementInputTaken += OnStartMovement;
            view.onRotationInputTaken += OnStartRotation;
            view.onDequeueBullet += OnDequeueBullet;

            InputSignals.onDisableTouch.AddListener(OnDisableTouch);
            InputSignals.onEnableTouch.AddListener(OnEnableTouch);
            GameSignals.onInputDataInitialize.AddListener(OnInputDataInitialize);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            view.onMovementInputTaken -= OnStartMovement;
            view.onDequeueBullet -= OnDequeueBullet;
            view.onRotationInputTaken -= OnStartRotation;

            InputSignals.onDisableTouch.RemoveListener(OnDisableTouch);
            InputSignals.onEnableTouch.RemoveListener(OnEnableTouch);
            GameSignals.onInputDataInitialize.RemoveListener(OnInputDataInitialize);
        }

        private void OnStartRotation(Vector3 arg0)
        {
            InputSignals.onRotationInputTaken.Dispatch(new RotationInputParams()
            {
                TurnRotation = arg0,
                TurnSpeed = view.Vo.TurnSpeed
            });
        }


        private void OnDequeueBullet()
        {
            GameSignals.onTriggerDequeuePoolableObject.Dispatch();
        }

        private void OnInputDataInitialize(LevelStartInputDataHolderParam inputData)
        {
            view.SetInputData(inputData);
        }


        private void OnStartMovement(float xValues, float zValues)
        {
            InputSignals.onMovementInputTaken.Dispatch(new MovementInputParams()
            {
                HorizontalValue = xValues,
                VerticalValue = zValues,
                MovementSpeed = view.Vo.MovementSpeed
            });
        }

        private void OnDisableTouch()
        {
            view.IsAvailableForTouch = false;
        }

        private void OnEnableTouch()
        {
            view.IsAvailableForTouch = true;
        }
    }
}