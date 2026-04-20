using UnityEngine;

namespace Signal.Core.Economy
{
    public class ResourceInfo
    {
        public Sprite Sprite { get; }
        public int Count { get; }

        public ResourceInfo(Sprite sprite, int count)
        {
            Sprite = sprite;
            Count = count;
        }
    }
}
