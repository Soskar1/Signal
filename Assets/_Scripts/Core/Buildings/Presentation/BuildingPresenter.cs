using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingPresenter : MonoBehaviour
    {
        private Building _building;

        public void Initialize(Building building)
        {
            _building = building;
        }

        public void Update()
        {
            if (_building == null)
            {
                return;
            }

            _building.Tick(Time.deltaTime);
        }
    }
}
