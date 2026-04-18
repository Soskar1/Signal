using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Buildings.Presentation;
using System.Collections.Generic;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Buildings
{
    public class BuildingsInstaller : MonoBehaviour
    {
        [SerializeField] private BuildingPresenter _buildingPresenterPrefab;
        [SerializeField] private List<BuildingDefinition> _buildingDefinitions;

        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory(container => new BuildingCatalog(_buildingDefinitions), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory<IBuildingPlacement>(container =>
                new BuildingPlacement(_buildingPresenterPrefab, container.Resolve<BuildingCatalog>()), Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
