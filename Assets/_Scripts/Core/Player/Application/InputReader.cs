using System;
using UnityEngine;

namespace Signal.Core.Player.Application
{
    internal class InputReader : IInputReader, IDisposable
    {
        private readonly Controls _controls;

        public Vector2 MousePosition => _controls.Player.MousePosition.ReadValue<Vector2>();
        public bool IsBuildButtonPressed => _controls.Player.Build.WasPressedThisFrame();

        public InputReader()
        {
            _controls = new Controls();
            _controls.Player.Enable();
        }

        public void Dispose()
        {
            _controls.Player.Disable();
            _controls.Dispose();
        }
    }
}
