using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Economy.Application;
using Signal.Core.Economy.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Economy
{
    public class EconomyInstaller : MonoBehaviour
    {
        [SerializeField] private List<ResourceDefinition> _resources;
        [SerializeField] private List<ResourceCategoryDefinition> _categories;

        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory(container => new ResourceCatalog(_resources), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory<IResourceQuery>(container => container.Resolve<ResourceCatalog>(), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterValue(_categories);
            containerBuilder.RegisterFactory<IResourceWallet>(container => new ResourceWallet(container.Resolve<ResourceCatalog>()), Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
