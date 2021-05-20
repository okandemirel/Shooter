using Modules.Core.Abstract.Model;
using Modules.Core.Concrete.Data;
using SRDebugger;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Concrete.Injectable.Controller
{
    public class OnSRDebuggerInitializerFixCommand : Command
    {
        [Inject] public IGameModel GameModel { get; set; }

        public override void Execute()
        {
            Retain();
            Debug.Log("/SrDebuggerFixCommand/ ---> Execute");
            //Settings.Instance.IsEnabled = false;
#if UNITY_EDITOR
            Settings.Instance.IsEnabled = false;
            if (Application.isEditor)
            {
                GameModel.IsEnableSrDebugger = true;
                SRDebug.Init();
                Release();
                return;
            }
#endif
#if UNITY_ANDROID
            //Bu alan release de kapatılacak
            GameModel.IsEnableSrDebugger = true;
            SRDebug.Init();

            Release();
            return;


#endif
            Application.RequestAdvertisingIdentifierAsync(IdfaCheck);
        }

        private void IdfaCheck(string advertisingId, bool trackingEnabled, string error)
        {
            Debug.Log("/SrDebuggerFixCommand/ --> IdfaCheck --> Execute");
            foreach (DeviceVo info in GameModel.TestDeviceList.List)
            {
                if (info.IDFA == advertisingId)
                {
                    GameModel.IsEnableSrDebugger = true;
                    SRDebug.Init();
                    break;
                }
            }

            Release();
        }
    }
}