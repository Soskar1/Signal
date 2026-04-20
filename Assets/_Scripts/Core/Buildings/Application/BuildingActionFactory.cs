using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Economy;
using Signal.Core.Entities;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingActionFactory
    {
        private readonly IResourceWallet _resourceWallet;
        private readonly IHealthApi _healthApi;
        private readonly IEntityQuery _entityQuery;

        public BuildingActionFactory(IResourceWallet resourceWallet, IHealthApi healthApi, IEntityQuery entityQuery)
        {
            _resourceWallet = resourceWallet;
            _healthApi = healthApi;
            _entityQuery = entityQuery;
        }

        public IBuildingAction Create(BuildingActionDefinition definition, Vector2 buildingWorldPosition)
        {
            return definition switch
            {
                IncreaseResourceActionDefinition increase => new IncreaseResourceAction(increase.Resources, increase.Amount, increase.CooldownInSeconds, _resourceWallet),
                ResourceConvertionActionDefinition convertion => new ResourceConvertionAction(convertion.From, convertion.To, convertion.FromAmount, convertion.ToAmount, convertion.CooldownInSeconds, _resourceWallet),
                ShootActionDefinition shoot => new ShootAction(shoot.Resource, shoot.ProjectilePrefab, shoot.Amount, shoot.CooldownInSeconds, _resourceWallet, _healthApi, _entityQuery, buildingWorldPosition),
                _ => new EmptyAction()
            };
        }
    }
}
