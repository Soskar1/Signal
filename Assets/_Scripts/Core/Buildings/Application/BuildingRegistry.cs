using Signal.Core.Buildings;
using Signal.Core.Buildings.Domain;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Entities.Application
{
    internal sealed class BuildingRegistry
    {
        private readonly Dictionary<EntityInstanceId, Building> _buildings = new();
        private readonly Dictionary<HealthOwnerId, EntityInstanceId> _buildingByHealthOwner = new();
        private readonly Dictionary<GridPosition, Building> _buildingByGridPosition = new();
        private readonly Dictionary<BuildingId, List<Building>> _buildingById = new();

        public void Add(Building building)
        {
            _buildings.Add(building.InstanceId, building);
            _buildingByHealthOwner.Add(building.HealthOwnerId, building.InstanceId);
            _buildingByGridPosition.Add(building.GridPosition, building);
            
            if (_buildingById.TryGetValue(building.Id, out var buildings))
            {
                buildings.Add(building);
            }
            else
            {
                _buildingById[building.Id] = new List<Building>() { building };
            }
        }

        public Building Get(EntityInstanceId instanceId) => _buildings[instanceId];

        public bool TryGet(HealthOwnerId ownerId, out Building building)
        {
            if (_buildingByHealthOwner.TryGetValue(ownerId, out var instanceId) &&
                _buildings.TryGetValue(instanceId, out building))
            {
                return true;
            }

            building = null;
            return false;
        }

        public bool TryGet(GridPosition gridPosition, out Building building)
        {
            if (_buildingByGridPosition.TryGetValue(gridPosition, out building))
            {
                return true;
            }

            building = null;
            return false;
        }

        public IEnumerable<Building> Get(BuildingId buildingId)
        {
            if (_buildingById.ContainsKey(buildingId))
            {
                return _buildingById[buildingId];
            }

            return new List<Building>();
        }

        public void Remove(EntityInstanceId instanceId)
        {
            var building = _buildings[instanceId];
            _buildings.Remove(instanceId);
            _buildingByHealthOwner.Remove(building.HealthOwnerId);
            _buildingByGridPosition.Remove(building.GridPosition);
        }

        public bool IsOccupied(GridPosition position)
        {
            return _buildingByGridPosition.ContainsKey(position);
        }
    }
}