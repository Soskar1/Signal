using Signal.Core.Economy;
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

        private IResourceObserver _resourceObserver;
        private IResourceQuery _resourceQuery;

        public void Initialize(BuildingDefinition buildingDefinition, BuildingDescriptionTooltip tooltip, BuildModePresenter buildModePresenter, IResourceObserver resourceObserver, IResourceQuery resourceQuery)
        {
            _buildingDefinition = buildingDefinition;
            _image.sprite = _buildingDefinition.DisplaySprite;
            _tooltip = tooltip;
            _buildModePresenter = buildModePresenter;

            _resourceObserver = resourceObserver;
            _resourceObserver.ResourceChanged += HandleResourceChanged;

            _resourceQuery = resourceQuery;

            _button.onClick.AddListener(() => EnterBuildMode());
        }

        private void HandleResourceChanged(object _, ResourceChangedEventArgs e)
        {
            var interactable = true;

            foreach (var resourceCost in _buildingDefinition.BuildingCost)
            {
                var resourceInfo = _resourceQuery.GetResourceInfo(resourceCost.ResourceId);
                
                if (resourceInfo.Count < resourceCost.Cost)
                {
                    interactable = false;
                    break;
                }
            }

            _button.interactable = interactable;
        }

        public void EnterBuildMode()
        {
            _buildModePresenter.EnterBuildMode(_buildingDefinition);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
            _resourceObserver.ResourceChanged -= HandleResourceChanged;
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
