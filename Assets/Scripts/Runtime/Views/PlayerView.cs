using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using Runtime.Key;
using UnityEngine;

namespace Runtime.Views
{
    public class PlayerView : RichView
    {
        #region Unity Actions

        #endregion

        [Header("Self Variables")]

        #region Self Variables

        #region Public Variables

        [Header("Data")]
        public PlayerVO Vo;

        [Space] public Transform GunObject;

        #endregion

        [Space]

        #region SerializedVariables

        [SerializeField]
        private CharacterController characterController;

        #endregion

        [Space]

        #region Private Variables

        private bool _startMovement;

        private float _desiredRotation;

        private float _rotationSpeed;

        #endregion

        #endregion

        protected override void Awake()
        {
            base.Awake();
            characterController = GetComponent<CharacterController>();
        }


        public void SetPlayerVo(LevelStartPlayerDataHolderParams playerData)
        {
            Vo = playerData.PlayerData;
        }


        public void UpdateInputPos(float horizontalInputValue, float verticalInputValue,
            float movementSpeed)
        {
            Vector3 move = new Vector3(horizontalInputValue * movementSpeed * Time.deltaTime, 0,
                verticalInputValue * movementSpeed * Time.deltaTime);

            move = (Camera.main.transform.forward * move.z) + (Camera.main.transform.right * move.x);
            move.y = 0;

            characterController.Move(new Vector3(move.x, 0,
                move.z));
        }

        public void SetRotation(Vector2 rotationValues, float turnSpeed)
        {
            float targetAngle = Mathf.Atan2(rotationValues.x, rotationValues.y) * Mathf.Rad2Deg +
                                Camera.main.transform.eulerAngles.y;

            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        }
    }
}