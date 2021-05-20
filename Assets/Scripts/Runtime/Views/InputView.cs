using System;
using System.Collections.Generic;
using Rich.Base.Runtime.Abstract.View;
using Rich.Base.Runtime.Extensions;
using Runtime.Data.ValueObject;
using Runtime.Key;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Runtime.Views
{
    public class InputView : RichView, IEventSystemHandler
    {
        #region Unity Actions

        public UnityAction<float, float> onMovementInputTaken = delegate { };

        public UnityAction<Vector3> onRotationInputTaken = delegate { };
        public UnityAction onDequeueBullet = delegate { };

        #endregion

        [Space]

        #region Self Variables

        #region Public Variables

        [Header("Data")]
        public InputVO Vo;

        [Space] public bool IsAvailableForTouch = true;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        protected override void Start()
        {
            base.Start();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (!IsAvailableForTouch) return;

            onRotationInputTaken?.Invoke(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement())
            {
                onDequeueBullet.Invoke();
            }


            if (Input.anyKey)
                onMovementInputTaken?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private bool IsPointerOverUIElement()
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        public void SetInputData(LevelStartInputDataHolderParam inputData)
        {
            Vo.MovementSpeed = inputData.MovementSpeed;
            Vo.TurnSpeed = inputData.TurnSpeed;
        }
    }
}