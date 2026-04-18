using UnityEngine;

namespace Signal.Core.Player
{
    public interface IInputReader
    {
        Vector2 MousePosition { get; }
        bool IsBuildButtonPressed { get; }
    }
}
