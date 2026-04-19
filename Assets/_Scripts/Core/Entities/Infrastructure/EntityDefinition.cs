using UnityEngine;

namespace Signal.Core.Entities.Infrastructure
{
    [CreateAssetMenu(fileName = "EntityDefinition", menuName = "Signal/Entities/Entity Definition")]
    internal class EntityDefinition : ScriptableObject
    {
        [SerializeField] private EntityId _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _health;
        [SerializeField] private float _moveSpeed;

        public string Id => _id.Id;
        public Sprite Sprite => _sprite;
        public int Health => _health;
        public float MoveSpeed => _moveSpeed;
    }
}