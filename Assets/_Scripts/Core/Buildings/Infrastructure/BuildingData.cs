using UnityEngine;

namespace Signal.Core.Buildings
{
    [CreateAssetMenu(fileName = "BuildingData", menuName = "Scriptable Objects/BuildingData")]
    internal class BuildingData : ScriptableObject
    {
        [SerializeField] private string m_name;
        [SerializeField] private string m_description;
        [SerializeField] private Sprite m_sprite;
        [SerializeField] private int m_health;

        public string Name => m_name;
        public string Description => m_description;
        public Sprite Sprite => m_sprite;
        public int Health => m_health;
    }
}