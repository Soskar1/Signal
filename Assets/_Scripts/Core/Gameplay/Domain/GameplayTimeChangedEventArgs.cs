using System;

namespace Signal.Core.Gameplay.Domain
{
    internal class GameplayTimeChangedEventArgs : EventArgs
    {
        public int Seconds { get; }
        public int Minutes { get; }

        public GameplayTimeChangedEventArgs(int seconds, int minutes)
        {
            Seconds = seconds;
            Minutes = minutes;
        }
    }
}
