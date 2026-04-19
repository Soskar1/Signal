using Reflex.Attributes;
using Signal.Core.Entities.Application;
using UnityEngine;

namespace Signal.Core.Entities
{
    public class EntityBootstrap : MonoBehaviour
    {
        private EntityLifecycle _lifecycle;

        [Inject]
        internal void Inject(EntityLifecycle lifecycle)
        {
            _lifecycle = lifecycle;
        }

        public void Initialize()
        {
            _lifecycle.Initialize();
        }

        public void OnDestroy()
        {
            _lifecycle.Dispose();
        }
    }
}
