using Reflex.Core;
using Reflex.Enums;
using Signal.Core.World.Application;
using Signal.Core.World.Infrastructure;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.World
{
    public static class WorldInstaller
    {
        public static ContainerBuilder InstallWorld(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(HealthRegistry), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory<IHealthApi>(container => new HealthApi(container.Resolve<HealthRegistry>()), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory<IEntityInstanceIdFactory>(container => new EntityInstanceIdFactory(), Lifetime.Singleton, Resolution.Lazy);
            return containerBuilder;
        }
    }
}
