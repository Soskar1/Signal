using Reflex.Attributes;
using UnityEngine;

namespace Signal.Core.UI
{
    public class ExitGameButton : MonoBehaviour
    {
        private Signal _signal;

        [Inject]
        public void Inject(Signal signal)
        {
            _signal = signal;
        }

        public void ExitGame()
        {
            _signal.Exit();
        }
    }
}