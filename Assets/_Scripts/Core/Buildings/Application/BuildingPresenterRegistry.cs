using Signal.Core.Buildings.Presentation;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingPresenterRegistry
    {
        private readonly Dictionary<EntityInstanceId, BuildingPresenter> _presenters = new();

        public void Add(EntityInstanceId instanceId, BuildingPresenter presenter)
        {
            _presenters.Add(instanceId, presenter);
        }

        public BuildingPresenter Get(EntityInstanceId instanceId)
        {
            return _presenters[instanceId];
        }

        public bool TryGet(EntityInstanceId instanceId, out BuildingPresenter presenter)
        {
            return _presenters.TryGetValue(instanceId, out presenter);
        }

        public void Remove(EntityInstanceId instanceId)
        {
            _presenters.Remove(instanceId);
        }
    }
}
