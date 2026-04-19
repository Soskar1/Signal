using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Buildings.Presentation;
using Signal.Core.Entities.Application;
using Signal.Core.World;
using System.Collections.Generic;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Buildings
{
    public class BuildingsInstaller : MonoBehaviour
    {
        [SerializeField] private BuildingGridSettings _gridSettings;
        [SerializeField] private BuildingPresenter _buildingPresenterPrefab;
        [SerializeField] private List<BuildingDefinition> _buildingDefinitions;
        [SerializeField] private List<BuildingCategoryDefinition> _buildingCategoryDefinitions;

        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterValue(_buildingCategoryDefinitions);
            containerBuilder.RegisterType(typeof(BuildingActionFactory), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory(container => new BuildingCatalog(_buildingDefinitions), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory(container => new BuildingGrid(_gridSettings.Origin, _gridSettings.CellSize), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(GridOccupancy), Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterType(typeof(BuildingRegistry), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(BuildingPresenterRegistry), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(BuildingLifecycle), Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterFactory(container =>
                new BuildingSpawner(_buildingPresenterPrefab,
                    container.Resolve<BuildingCatalog>(),
                    container.Resolve<BuildingActionFactory>(),
                    container.Resolve<BuildingGrid>(),
                    container.Resolve<GridOccupancy>(),
                    container.Resolve<BuildingRegistry>(),
                    container.Resolve<BuildingPresenterRegistry>(),
                    container.Resolve<IHealthApi>(),
                    container.Resolve<IEntityInstanceIdFactory>()),
                Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
