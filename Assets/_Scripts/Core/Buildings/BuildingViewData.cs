using UnityEngine;

namespace Signal.Core.Buildings
{
    public struct BuildingViewData
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Sprite { get; }

        public BuildingViewData(string name, string description, Sprite sprite)
        {
            Name = name;
            Description = description;
            Sprite = sprite;
        }
    }
}
