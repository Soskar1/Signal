using Reflex.Attributes;
using UnityEngine;

namespace Signal.Core.UI
{
    public class MainMenuButton : MonoBehaviour
    {
        private Signal _signal;

        [Inject]
        public void Inject(Signal signal)
        {
            _signal = signal;
        }

        public void GoToMainMenu()
        {
            _signal.TransitionToMainMenu();
        }
    }
}