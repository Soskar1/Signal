using Signal.Core.Entities;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _hitDistance = 0.15f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _lifeTime = 1.5f;

        private EntityInstanceId _target;
        private IEntityQuery _entityQuery;
        private IHealthApi _healthApi;

        private Vector2 _lastMovementDirection;

        public void Initialize(EntityInstanceId target, IEntityQuery entityQuery, IHealthApi healthApi)
        {
            _target = target;
            _entityQuery = entityQuery;
            _healthApi = healthApi;

            Destroy(gameObject, _lifeTime);
        }

        public void Update()
        {
            var entityInfo = _entityQuery.GetEntityInfo(_target);

            if (entityInfo == null)
            {
                entityInfo = _entityQuery.GetNearestEntity(transform.position);

                if (entityInfo != null)
                {
                    _target = entityInfo.InstanceId;
                }
                else
                {
                    transform.position = new Vector2(transform.position.x + _lastMovementDirection.x * _speed * Time.deltaTime, transform.position.y + _lastMovementDirection.y * _speed * Time.deltaTime);
                    return;
                }
            }

            var targetPosition = entityInfo.WorldPosition;
            var nextPosition = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            _lastMovementDirection = (targetPosition - (Vector2)transform.position).normalized;

            float angle = Mathf.Atan2(_lastMovementDirection.y, _lastMovementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            transform.position = nextPosition;

            if (Vector2.Distance(transform.position, targetPosition) < _hitDistance)
            {
                _healthApi.TryApplyDamage(_target.HealthOwnerId, _damage);
                Destroy(gameObject);
            }
        }
    }
}
