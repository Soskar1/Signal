using System;
using UnityEngine;

namespace Signal.Core.Gameplay.Domain
{
    internal class GameplayTime
    {
        private float _elapsedTime;
        public int Minutes { get; private set; }

        private int _seconds;
        public int Seconds
        {
            get => _seconds;
            private set
            {
                if (value == _seconds)
                {
                    return;
                }

                _seconds = value;

                var args = new GameplayTimeChangedEventArgs(Seconds, Minutes);
                GameplayTimeChanged?.Invoke(this, args);
            }
        }

        public event EventHandler<GameplayTimeChangedEventArgs> GameplayTimeChanged;

        public void Tick(float deltaTime)
        {
            _elapsedTime += Time.deltaTime;

            Minutes = Mathf.FloorToInt(_elapsedTime / 60f);
            Seconds = Mathf.FloorToInt(_elapsedTime % 60f);
        }
    }
}
