using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "BuildingGridSettings", menuName = "Signal/Buildings/Grid Settings")]
    internal class BuildingGridSettings : ScriptableObject
    {
        [SerializeField] private Vector2 _origin;
        [SerializeField] private float _cellSize = 1f;

        public Vector2 Origin => _origin;
        public float CellSize => _cellSize;
    }
}
