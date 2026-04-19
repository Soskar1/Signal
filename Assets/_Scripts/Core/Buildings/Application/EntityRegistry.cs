using Signal.Core.Buildings.Domain;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Entities.Application
{
    internal sealed class BuildingRegistry
    {
        private readonly Dictionary<EntityInstanceId, Building> _buildings = new();
        private readonly Dictionary<HealthOwnerId, EntityInstanceId> _buildingByHealthOwner = new();

        public void Add(Building building)
        {
            _buildings.Add(building.InstanceId, building);
            _buildingByHealthOwner.Add(building.HealthOwnerId, building.InstanceId);
        }

        public Building Get(EntityInstanceId instanceId) => _buildings[instanceId];

        public bool TryGetByHealthOwner(HealthOwnerId ownerId, out Building building)
        {
            if (_buildingByHealthOwner.TryGetValue(ownerId, out var instanceId) &&
                _buildings.TryGetValue(instanceId, out building))
            {
                return true;
            }

            building = null;
            return false;
        }

        public void Remove(EntityInstanceId instanceId)
        {
            var building = _buildings[instanceId];
            _buildings.Remove(instanceId);
            _buildingByHealthOwner.Remove(building.HealthOwnerId);
        }
    }
}