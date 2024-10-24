using System;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceViewData
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public Sprite EnableStateIcon { get; private set; }
        [field: SerializeField] public Sprite DisabledStateIcon { get; private set; }
    }
}