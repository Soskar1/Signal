using UnityEngine;

namespace Signal.Core.Buildings
{
    [CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
    internal class BuildingData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _health;

        public string Name => _name;
        public string Description => _description;
        public Sprite Sprite => _sprite;
        public int Health => _health;
    }
}