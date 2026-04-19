using Signal.Core.Economy;

namespace Signal.Core.Buildings.Domain
{
    internal sealed class ResourceConvertionAction : IBuildingAction
    {
        private readonly ResourceId _convertFrom;
        private readonly ResourceId _convertTo;
        private readonly int _amount;
        private readonly float _cooldownInSeconds;

        private readonly IResourceWallet _resourceWallet;

        private double _elapsed;

        public ResourceConvertionAction(ResourceId convertFrom, ResourceId convertTo, int amount, float cooldownInSeconds, IResourceWallet resourceWallet)
        {
            _convertFrom = convertFrom;
            _convertTo = convertTo;
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
            bool success = _resourceWallet.TryWithdraw(_convertFrom, _amount);
            if (success)
            {
                _resourceWallet.Add(_convertTo, _amount);
            }
        }
    }
}
