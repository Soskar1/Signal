using Signal.Core.Gameplay.Domain;

namespace Signal.Core.Gameplay.Application
{
    internal class Timer
    {
        private readonly GameplayTime _time;
        private bool _enabled = true;
        
        public Timer(GameplayTime time)
        {
            _time = time;
        }

        public void Stop()
        {
            _enabled = false;
        }

        public void Tick(float deltaTime)
        {
            if (!_enabled)
            {
                return;
            }

            _time.Tick(deltaTime);
        }
    }
}
