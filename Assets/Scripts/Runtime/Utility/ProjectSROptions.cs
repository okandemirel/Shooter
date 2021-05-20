using System.ComponentModel;
using Runtime.Signals;

namespace Runtime.Utility
{
    public class ProjectSROptions
    {
        [Inject] public SRSignals SRSignals { get; set; }

        //private Color primaryColor, secondaryColor;

        private int _level;


        // [Inject] public ApplovinSignals AdSignals { get; set; }
        //
        // // public int CameraOffset { get; set; }
        // public void ShowApplovinDebugger()
        // {
        //     AdSignals.ShowDebugger.Dispatch();
        // }
        //
        // public void MaxSDKDebugger()
        // {
        //     MaxSdk.ShowMediationDebugger();
        // }
        //
        // public void TryShowBanner()
        // {
        //     AdSignals.ShowBanner.Dispatch();
        // }
        //
        // public void DestroyBanner()
        // {
        //     AdSignals.DestroyBanner.Dispatch();
        // }
        //
        // public void HideBanner()
        // {
        //     AdSignals.HideBanner.Dispatch();
        // }
        //
        // public void TryShowInterstitial()
        // {
        //     AdSignals.ShowInterstitial.Dispatch();
        // }

        [Category("Level Behaviour")]
        public void NextLevel()
        {
            SRSignals.onNextLevel.Dispatch();
        }

        [Category("Level Behaviour")]
        public void RestartLevel()
        {
            SRSignals.onRestartLevel.Dispatch();
        }

        [Category("Level Behaviour")]
        public void PreviousLevel()
        {
            SRSignals.onPreviousLevel.Dispatch();
        }

        [Category("Level Behaviour")]
        public void ClearGameData()
        {
            SRSignals.onClearGameData.Dispatch();
        }

        [Category("Level Behaviour")]
        public int MoveToLevel
        {
            get => _level;
            set
            {
                _level = value;
                SRSignals.onMoveToLevel.Dispatch(_level);
            }
        }
    }
}