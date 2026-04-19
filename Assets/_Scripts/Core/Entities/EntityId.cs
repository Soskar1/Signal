using UnityEngine;

namespace Signal.Core.Entities
{
    [CreateAssetMenu(fileName = "EntityId", menuName = "Signal/Entities/Entity Id")]
    public class EntityId : ScriptableObject
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}
