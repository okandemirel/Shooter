using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class SRSignals
    {
        public Signal onClearGameData = new Signal();
        public Signal onNextLevel = new Signal();
        public Signal onRestartLevel = new Signal();
        public Signal onPreviousLevel = new Signal();
        public Signal<int> onMoveToLevel = new Signal<int>();
    }
}