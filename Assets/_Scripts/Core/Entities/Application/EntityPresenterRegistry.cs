using Signal.Core.Entities.Presentation;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Entities.Application
{
    internal class EntityPresenterRegistry
    {
        private readonly Dictionary<EntityInstanceId, EntityPresenter> _presenters = new();

        public void Add(EntityInstanceId instanceId, EntityPresenter presenter)
        {
            _presenters.Add(instanceId, presenter);
        }

        public EntityPresenter Get(EntityInstanceId instanceId)
        {
            return _presenters[instanceId];
        }

        public bool TryGet(EntityInstanceId instanceId, out EntityPresenter presenter)
        {
            return _presenters.TryGetValue(instanceId, out presenter);
        }

        public void Remove(EntityInstanceId instanceId)
        {
            _presenters.Remove(instanceId);
        }
    }
}
