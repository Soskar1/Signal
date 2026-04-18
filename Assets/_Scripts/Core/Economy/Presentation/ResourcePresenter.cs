using Signal.Core.Economy.Domain;
using Signal.Core.Economy.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Economy.Presentation
{
    internal class ResourcePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField] private Image _image;

        private Resource _resource;

        public void Initialize(Resource resource, ResourceDefinition data)
        {
            _resource = resource;

            _image.sprite = data.Sprite;
            _countText.text = resource.Count.ToString();

            _resource.ResourceChanged += OnResourceChanged;
        }

        private void OnDestroy()
        {
            if (_resource != null)
                _resource.ResourceChanged -= OnResourceChanged;
        }

        private void OnResourceChanged(object sender, ResourceChangedEventArgs args)
        {
            _countText.text = args.Count.ToString();
        }
    }
}