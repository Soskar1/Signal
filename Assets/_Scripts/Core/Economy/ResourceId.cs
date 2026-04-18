using UnityEngine;

namespace Signal.Core.Economy
{
    [CreateAssetMenu(fileName = "ResourceId", menuName = "Signal/Economy/ResourceId")]
    public class ResourceId : ScriptableObject
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}