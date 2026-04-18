using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _baseRenderer;
        [SerializeField] private SpriteRenderer _headRenderer;

        private Building _building;

        public void Initialize(Building building, Sprite baseSprite, Sprite headSprite)
        {
            _building = building;
            _baseRenderer.sprite = baseSprite;
            _headRenderer.sprite = headSprite;
        }

        public void Update()
        {
            if (_building == null)
            {
                return;
            }

            _building.Tick(Time.deltaTime);
        }
    }
}
