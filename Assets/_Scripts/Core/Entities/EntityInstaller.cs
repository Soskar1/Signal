using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Entities.Application;
using Signal.Core.Entities.Infrastructure;
using Signal.Core.Entities.Presentation;
using Signal.Core.World;
using Singal.Core.Entities.Application;
using System.Collections.Generic;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Entities
{
    public class EntityInstaller : MonoBehaviour
    {
        [SerializeField] private List<EntityDefinition> _entityDefinitions;
        [SerializeField] private EntityPresenter _entityPrefab;
        [SerializeField] private Transform _entityPoolParent;

        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory(container => new EntityDefinitionCatalog(_entityDefinitions), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(EntityFactory), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(EntityRegistry), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterType(typeof(EntityLifecycle), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory<IEntityObserver>(container => container.Resolve<EntityLifecycle>(), Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterType(typeof(EntityPresenterRegistry), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory(container => new EntityPresenterPool(_entityPrefab, _entityPoolParent), Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterFactory<IEntitySpawner>(container => new EntitySpawner(
                    container.Resolve<EntityFactory>(),
                    container.Resolve<EntityPresenterPool>(),
                    container.Resolve<EntityRegistry>(),
                    container.Resolve<EntityPresenterRegistry>(),
                    container.Resolve<EntityDefinitionCatalog>(),
                    container.Resolve<IHealthApi>()),
                Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterFactory<IEntityMovement>(container => new EntityMovement(
                    container.Resolve<EntityRegistry>(),
                    container.Resolve<EntityDefinitionCatalog>(),
                    container.Resolve<EntityPresenterRegistry>()),
                Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterFactory<IEntityQuery>(container => new EntityQuery(
                    container.Resolve<EntityRegistry>(),
                    container.Resolve<EntityPresenterRegistry>()),
                Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
