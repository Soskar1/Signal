using Signal.Core.Entities.Presentation;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Entities.Application
{
    internal class EntityPresenterPool
    {
        private readonly Dictionary<string, Queue<EntityPresenter>> _pool = new();
        private readonly EntityPresenter _prefab;
        private readonly Transform _parent;

        public EntityPresenterPool(EntityPresenter prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public EntityPresenter Get(EntityId entityId)
        {
            if (!_pool.TryGetValue(entityId.Id, out var queue))
            {
                queue = new Queue<EntityPresenter>();
                _pool[entityId.Id] = queue;
            }

            EntityPresenter presenter;

            if (queue.Count > 0)
            {
                presenter = queue.Dequeue();
                presenter.gameObject.SetActive(true);
            }
            else
            {
                presenter = Object.Instantiate(_prefab, _parent);
            }

            return presenter;
        }

        public void Release(EntityPresenter presenter, EntityId entityId)
        {
            presenter.gameObject.SetActive(false);

            if (!_pool.TryGetValue(entityId.Id, out var queue))
            {
                queue = new Queue<EntityPresenter>();
                _pool[entityId.Id] = queue;
            }

            queue.Enqueue(presenter);
        }
    }
}
