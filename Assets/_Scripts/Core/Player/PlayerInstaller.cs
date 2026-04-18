using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Player.Application;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory<IInputReader>(container => new InputReader(), Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
