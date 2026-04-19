using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Player.Application;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Player
{
    public static class PlayerInstaller
    {
        public static ContainerBuilder InstallPlayer(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory<IInputReader>(container => new InputReader(), Lifetime.Singleton, Resolution.Lazy);
            return containerBuilder;
        }
    }
}
