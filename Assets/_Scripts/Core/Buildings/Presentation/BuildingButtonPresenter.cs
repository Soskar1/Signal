using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingButtonPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _image;

        private BuildingDefinition _buildingDefinition;
        private BuildingDescriptionTooltip _tooltip;

        public void Initialize(BuildingDefinition buildingDefinition, BuildingDescriptionTooltip tooltip)
        {
            _buildingDefinition = buildingDefinition;
            _image.sprite = _buildingDefinition.Sprite;
            _tooltip = tooltip;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tooltip.Display(_buildingDefinition);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tooltip.Hide();
        }
    }
}
