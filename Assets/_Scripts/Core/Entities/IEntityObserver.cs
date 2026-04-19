using System;

namespace Signal.Core.Entities
{
    public interface IEntityObserver
    {
        public event EventHandler<EntityDiedEventArgs> EntityDied;
    }
}
