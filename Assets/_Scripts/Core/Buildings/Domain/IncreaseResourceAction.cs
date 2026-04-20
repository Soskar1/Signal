using Signal.Core.Economy;
using System.Collections.Generic;

namespace Signal.Core.Buildings.Domain
{
    internal sealed class IncreaseResourceAction : IBuildingAction
    {
        private readonly List<ResourceId> _resources;
        private readonly int _amount;
        private readonly float _cooldownInSeconds;

        private readonly IResourceWallet _resourceWallet;

        private double _elapsed;

        public IncreaseResourceAction(List<ResourceId> resources, int amount, float cooldownInSeconds, IResourceWallet resourceWallet)
        {
            _resources = resources;
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
            foreach (var resource in _resources)
            {
                _resourceWallet.Add(resource, _amount);
            }
        }
    }
}
