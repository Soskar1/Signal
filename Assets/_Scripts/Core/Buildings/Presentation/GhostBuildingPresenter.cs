using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    public class GhostBuildingPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Color _invalidBuildingPlacementColor;
        [SerializeField] private Color _validBuildingPlacementColor;

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
            _renderer.color = _validBuildingPlacementColor;
        }

        public void DisplayAsInvalid()
        {
            _renderer.color = _invalidBuildingPlacementColor;
        }
    }
}