using System;

namespace Signal.Core.Entities
{
    public class EntityDiedEventArgs : EventArgs
    {
        public EntityInfo EntityInfo { get; }

        public EntityDiedEventArgs(EntityInfo entityInfo)
        {
            EntityInfo = entityInfo;
        }
    }
}
