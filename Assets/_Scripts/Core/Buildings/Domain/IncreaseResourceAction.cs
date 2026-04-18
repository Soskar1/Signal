using Signal.Core.Economy;

namespace Signal.Core.Buildings.Domain
{
    internal sealed class IncreaseResourceAction : IBuildingAction
    {
        private readonly ResourceId _resourceId;
        private readonly int _amount;
        private readonly float _cooldownInSeconds;

        private readonly IResourceWallet _resourceWallet;

        private double _elapsed;

        public IncreaseResourceAction(ResourceId resourceId, int amount, float cooldownInSeconds, IResourceWallet resourceWallet)
        {
            _resourceId = resourceId;
            _amount = amount;
            _cooldownInSeconds = cooldownInSeconds;
            _resourceWallet = resourceWallet;
        }

        public void Tick(double deltaTime)
        {
            _elapsed += deltaTime;

            if (_elapsed < _cooldownInSeconds)
                return;

            _elapsed = 0;
            Execute();
        }

        public void Execute()
        {
            _resourceWallet.Add(_resourceId, _amount);
        }
    }
}
