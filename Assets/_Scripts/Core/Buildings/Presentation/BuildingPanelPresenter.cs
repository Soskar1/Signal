using Reflex.Attributes;
using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingPanelPresenter : MonoBehaviour
    {
        [SerializeField] private BuildingDescriptionTooltip _tooltip;
        [SerializeField] private BuildModePresenter _buildModePresenter;

        [SerializeField] private BuildingCategoryPresenter _buildingCategoryPresenter;
        [SerializeField] private BuildingButtonPresenter _buildingButtonPrefab;

        [SerializeField] private Transform _buildingButtonContainer;
        [SerializeField] private Transform _categoryButtonContainer;

        private BuildingCatalog _buildingCatalog;
        private IEnumerable<BuildingCategoryDefinition> _buildingCategories;

        [Inject]
        public void Inject(BuildingCatalog buildingCatalog, List<BuildingCategoryDefinition> buildingCategories)
        {
            _buildingCatalog = buildingCatalog;
            _buildingCategories = buildingCategories;
        }

        public void Initialize()
        {
            var buildingButtons = new Dictionary<BuildingCategory, List<BuildingButtonPresenter>>();

            foreach (var definition in _buildingCatalog.Buildings)
            {
                if (!definition.IsConstructable)
                {
                    continue;
                }

                var presenter = Instantiate(_buildingButtonPrefab, _buildingButtonContainer);
                presenter.Initialize(definition, _tooltip, _buildModePresenter);

                if (!buildingButtons.TryGetValue(definition.Category, out var buttonList))
                {
                    buildingButtons.Add(definition.Category, new List<BuildingButtonPresenter>() { presenter });
                }
                else
                {
                    buttonList.Add(presenter);
                }

                presenter.gameObject.SetActive(false);
            }

            var allBuildingButtons = buildingButtons.Values.SelectMany(bulidingButton => bulidingButton);

            foreach (var category in _buildingCategories)
            {
                if (category.Category == BuildingCategory.None)
                {
                    continue;
                }

                var categoryButton = Instantiate(_buildingCategoryPresenter, _categoryButtonContainer);

                var categoryBuildingButtons = buildingButtons[category.Category];
                var otherButtons = allBuildingButtons.Except(categoryBuildingButtons);
                categoryButton.Initialize(category.Sprite, categoryBuildingButtons, otherButtons);
            }

            var firstCategory = buildingButtons.Values.First();
            foreach (var button in firstCategory)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
