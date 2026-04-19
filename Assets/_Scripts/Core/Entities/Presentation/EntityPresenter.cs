using Signal.Core.Entities.Domain;
using UnityEngine;

namespace Signal.Core.Entities.Presentation
{
    internal class EntityPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        private Entity _entity;

        public void Initialize(Entity entity, Sprite sprite)
        {
            _entity = entity;
            _renderer.sprite = sprite;
        }
    }
}