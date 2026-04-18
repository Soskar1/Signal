using Reflex.Attributes;
using Signal.Core.Economy.Domain;
using Signal.Core.Economy.Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Economy.Presentation
{
    internal class ResourcePanelPresenter : MonoBehaviour
    {
        [SerializeField] private ResourceCategoryPresenter _categoryPresenterPrefab;
        [SerializeField] private ResourcePresenter _resourcePresenterPrefab;
        [SerializeField] private Transform _categoryContainer;

        private ResourceCatalog _resourceCatalog;
        private IEnumerable<ResourceCategoryDefinition> _categoryDefinitions;

        [Inject]
        public void Inject(ResourceCatalog catalog, List<ResourceCategoryDefinition> definitions)
        {
            _resourceCatalog = catalog;
            _categoryDefinitions = definitions;
        }

        public void Initialize()
        {
            var categories = new Dictionary<ResourceCategory, ResourceCategoryPresenter>();

            foreach (var definition in _categoryDefinitions)
            {
                var presenter = Instantiate(_categoryPresenterPrefab, _categoryContainer);
                presenter.Initialize(definition);

                categories.Add(definition.Category, presenter);
            }

            foreach (var resourceEntry in _resourceCatalog.Entries)
            {
                var categoryPresenter = categories[resourceEntry.Category];
                var resourcePresenter = Instantiate(_resourcePresenterPrefab, categoryPresenter.ResourceContainer);

                resourcePresenter.Initialize(resourceEntry.Resource, resourceEntry.ResourceDefinition);
            }
        }
    }
}
