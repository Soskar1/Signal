using Signal.Core.Buildings.Domain;
using Signal.Core.Entities.Application;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingQuery : IBuildingQuery
    {
        private readonly GridSnapper _grid;
        private readonly BuildingRegistry _registry;

        public BuildingQuery(GridSnapper gridSnapper, BuildingRegistry registry)
        {
            _grid = gridSnapper;
            _registry = registry;
        }

        public BuildingInfo GetBuildingAt(Vector2 worldPosition)
        {
            var gridPosition = _grid.GetGridPosition(worldPosition);
            var buildingExists = _registry.TryGet(gridPosition, out Building building);

            if (buildingExists)
            {
                return ToBuildingInfo(building);
            }

            return null;
        }

        public IEnumerable<BuildingInfo> GetBuildingInfo(BuildingId buildingId)
        {
            foreach (var building in _registry.Get(buildingId))
            {
                yield return ToBuildingInfo(building);
            }
        }

        private BuildingInfo ToBuildingInfo(Building building)
        {
            var buildingPosition = _grid.GetSnappedWorldPosition(building.GridPosition);
            return new BuildingInfo(building.InstanceId, building.Id, buildingPosition);
        }
    }
}
