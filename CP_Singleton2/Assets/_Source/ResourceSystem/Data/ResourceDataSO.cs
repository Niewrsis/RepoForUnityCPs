using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourceDataSO", menuName = "SO/New Resource Data")]
    public class ResourceDataSO : ScriptableObject
    {
        [field:SerializeField] public List<ResourceData> ResourceData { get; private set; }

        public bool TryGetEnableTime(ResourceType resourceType, out float time)
        {
            time = 0;
            foreach (var timeData in ResourceData)
            {
                if (timeData.ResourceType == resourceType)
                {
                    time = timeData.EnableTime;
                    return true;
                }
            }
            return false;
        }
        public bool TryGetDisabledTime(ResourceType resourceType, out float time)
        {
            time = 0;
            foreach (var timeData in ResourceData)
            {
                if (timeData.ResourceType == resourceType)
                {
                    time = timeData.DisableTime;
                    return true;
                }
            }
            return false;
        }
    }
}