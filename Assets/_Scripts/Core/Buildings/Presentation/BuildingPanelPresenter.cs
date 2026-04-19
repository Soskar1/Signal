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
            var buildingButtonsByCategory = new Dictionary<BuildingCategory, List<BuildingButtonPresenter>>();

            foreach (var definition in _buildingCatalog.Buildings)
            {
                if (!definition.IsConstructable)
                {
                    continue;
                }

                var presenter = Instantiate(_buildingButtonPrefab, _buildingButtonContainer);
                presenter.Initialize(definition, _tooltip, _buildModePresenter);

                if (!buildingButtonsByCategory.TryGetValue(definition.Category, out var buttonList))
                {
                    buildingButtonsByCategory.Add(definition.Category, new List<BuildingButtonPresenter>() { presenter });
                }
                else
                {
                    buttonList.Add(presenter);
                }

                presenter.gameObject.SetActive(false);
            }

            var allBuildingButtons = buildingButtonsByCategory.Values.SelectMany(bulidingButton => bulidingButton);
            var categoryButtonsByDefinition = new Dictionary<BuildingCategoryDefinition, BuildingCategoryPresenter>();
            var categoryButtonsByCategory = new Dictionary<BuildingCategory, BuildingCategoryPresenter>();

            foreach (var category in _buildingCategories)
            {
                if (category.Category == BuildingCategory.None)
                {
                    continue;
                }

                var categoryButton = Instantiate(_buildingCategoryPresenter, _categoryButtonContainer);
                categoryButtonsByDefinition.Add(category, categoryButton);
                categoryButtonsByCategory.Add(category.Category, categoryButton);
            }

            foreach ((var category, var button) in categoryButtonsByDefinition)
            {
                var categoryBuildingButtons = buildingButtonsByCategory[category.Category];
                var otherBuildingButtons = allBuildingButtons.Except(categoryBuildingButtons);
                var otherCategoryButtons = categoryButtonsByDefinition.Values.Except(new List<BuildingCategoryPresenter>() { button });

                button.Initialize(category.Sprite, categoryBuildingButtons, otherBuildingButtons, otherCategoryButtons);
            }

            (var firstCategory, var buildingButtons) = buildingButtonsByCategory.First();
            var categoryTab = categoryButtonsByCategory[firstCategory];
            categoryTab.ActivateTab();
            foreach (var button in buildingButtons)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
