using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    [System.Serializable]
    public abstract class BuildingAction
    {
        [SerializeField] private int _cooldownInSeconds;

        public bool HasAction => true;

        private double _timer;

        public void Tick(double deltaTime)
        {
            if (!HasAction)
            {
                return;
            }

            _timer += deltaTime;

            if (_timer >= _cooldownInSeconds)
            {
                Execute();
                _timer = 0;
            }
        }

        public abstract void Execute();
    }
}