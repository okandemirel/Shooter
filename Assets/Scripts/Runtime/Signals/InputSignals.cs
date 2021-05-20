using Runtime.Key;
using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class InputSignals : Signal
    {
        public Signal<MovementInputParams> onMovementInputTaken = new Signal<MovementInputParams>();
        public Signal<RotationInputParams> onRotationInputTaken = new Signal<RotationInputParams>();

        public Signal onEnableTouch = new Signal();
        public Signal onDisableTouch = new Signal();
    }
}