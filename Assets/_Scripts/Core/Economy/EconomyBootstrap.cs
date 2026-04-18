using Signal.Core.Economy.Presentation;
using UnityEngine;

namespace Signal.Core.Economy
{
    public class EconomyBootstrap : MonoBehaviour
    {
        [SerializeField] private ResourcePanelPresenter _resourcePanel;

        public void Initialize()
        {
            _resourcePanel.Initialize();
        }
    }
}
