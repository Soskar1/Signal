using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    public class GhostBuildingPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Color _invalidBuildingSpawnerColor;
        [SerializeField] private Color _validBuildingSpawnerColor;

        public void Display(Sprite buildingSprite)
        {
            _renderer.sprite = buildingSprite;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void DisplayAsValid()
        {
            _renderer.color = _validBuildingSpawnerColor;
        }

        public void DisplayAsInvalid()
        {
            _renderer.color = _invalidBuildingSpawnerColor;
        }
    }
}