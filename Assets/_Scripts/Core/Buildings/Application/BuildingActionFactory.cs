using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Economy;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingActionFactory
    {
        private readonly IResourceWallet _resourceWallet;

        public BuildingActionFactory(IResourceWallet resourceWallet)
        {
            _resourceWallet = resourceWallet;
        }

        public IBuildingAction Create(BuildingActionDefinition definition)
        {
            return definition switch
            {
                IncreaseResourceActionDefinition increase => new IncreaseResourceAction(increase.ResourceId, increase.Amount, increase.CooldownInSeconds, _resourceWallet),
                ResourceConvertionActionDefinition convertion => new ResourceConvertionAction(convertion.From, convertion.To, convertion.Amount, convertion.CooldownInSeconds, _resourceWallet),
                _ => new EmptyAction()
            };
        }
    }
}
