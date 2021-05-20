using Cinemachine;
using Rich.Base.Runtime.Abstract.View;
using UnityEngine;

namespace Runtime.Views
{
    public class CameraView : RichView
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineFreeLook _freeLookCamera;

        #endregion

        #endregion


        public void SetCameraTarget(GameObject target)
        {
            _freeLookCamera.Follow = target.transform;
            _freeLookCamera.LookAt = target.transform;
        }
    }
}