using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourceViewDataSO", menuName = "SO/New Resource Data View")]
    public class ResourceViewDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceViewData> ResourceData { get; private set; }

        public bool TryGetEnabledIcon(ResourceType resourceType, out Sprite icon)
        {
            icon = null;
            foreach(var viewData in ResourceData)
            {
                if(viewData.ResourceType == resourceType)
                {
                    icon = viewData.EnableStateIcon;
                    return true;
                }
            }
            return false;
        }
        public bool TryGetDisabledIcon(ResourceType resourceType, out Sprite icon)
        {
            icon = null;
            foreach (var viewData in ResourceData)
            {
                if (viewData.ResourceType == resourceType)
                {
                    icon = viewData.DisabledStateIcon;
                    return true;
                }
            }
            return false;
        }
    }
}