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
        [SerializeField] private int _attackDamage;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackDistance;

        public EntityId Id => _id;
        public Sprite Sprite => _sprite;
        public int Health => _health;
        public int AttackDamage => _attackDamage;
        public float MoveSpeed => _moveSpeed;
        public float AttackSpeed => _attackSpeed;
        public float AttackDistance => _attackDistance;
    }
}