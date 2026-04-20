using Reflex.Attributes;
using UnityEngine;

namespace Signal.Core.Bootstrap
{
    internal class RootBootstrap : MonoBehaviour
    {
        private Signal _signal;

        [Inject]
        public void Inject(Signal signal)
        {
            _signal = signal;
        }

        public void Start() => _signal.TransitionToMainMenu();
    }
}
