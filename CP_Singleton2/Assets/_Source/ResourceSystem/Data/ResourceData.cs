using System;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceData
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public float EnableTime { get; private set; }
        [field: SerializeField] public float DisableTime { get; private set; }

    }
}