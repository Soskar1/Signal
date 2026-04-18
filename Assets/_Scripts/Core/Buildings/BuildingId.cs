using UnityEngine;

namespace Signal.Core.Buildings
{
    [CreateAssetMenu(fileName = "BuildingId", menuName = "Signal/Buildings/Building Id")]
    public class BuildingId : ScriptableObject
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}
