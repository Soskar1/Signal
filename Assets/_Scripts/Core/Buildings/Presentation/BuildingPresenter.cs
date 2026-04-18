using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        private Building _building;

        public void Initialize(Building building, Sprite sprite)
        {
            _building = building;
            _renderer.sprite = sprite;
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
