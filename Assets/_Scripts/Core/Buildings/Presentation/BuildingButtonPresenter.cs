using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingButtonPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private BuildingDefinition _buildingDefinition;
        private BuildingDescriptionTooltip _tooltip;
        private BuildModePresenter _buildModePresenter;

        public void Initialize(BuildingDefinition buildingDefinition, BuildingDescriptionTooltip tooltip, BuildModePresenter buildModePresenter)
        {
            _buildingDefinition = buildingDefinition;
            _image.sprite = _buildingDefinition.DisplaySprite;
            _tooltip = tooltip;
            _buildModePresenter = buildModePresenter;

            _button.onClick.AddListener(() => EnterBuildMode());
        }

        public void EnterBuildMode()
        {
            // TODO: add validation

            _buildModePresenter.EnterBuildMode(_buildingDefinition);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
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
