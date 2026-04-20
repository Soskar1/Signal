using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _baseRenderer;
        [SerializeField] private SpriteRenderer _headRenderer;
        [SerializeField] private BuildingHealthBar _buildingHealthBar;
        [SerializeField] private Animator _animator;

        private Building _building;

        public void Initialize(Building building, Sprite baseSprite, Sprite headSprite, RuntimeAnimatorController animatorController)
        {
            _building = building;
            _baseRenderer.sprite = baseSprite;
            _headRenderer.sprite = headSprite;
            _animator.runtimeAnimatorController = animatorController;
        }

        public void Update()
        {
            if (_building == null)
            {
                return;
            }

            _building.Tick(Time.deltaTime);
        }

        public void UpdateHealthBar(int currentHealth, int maxHealth)
        {
            _buildingHealthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
}
