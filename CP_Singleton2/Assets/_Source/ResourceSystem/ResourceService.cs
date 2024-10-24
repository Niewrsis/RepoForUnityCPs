using ResourceSystem.Data;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourceService
    {
        private static ResourceService instance;
        public static ResourceService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceService();
                }

                return instance;
            }
        }
        private ResourceDataSO _resourceData;
        private ResourceDataSO resourceData
        {
            get
            {
                if (_resourceData == null)
                {
                    _resourceData = Resources.Load("ResourceData") as ResourceDataSO;
                }
                return _resourceData;
            }
        }
        public void SetEnabledTime(ref float resourceTime, ResourceType resourceType)
        {
            if (resourceData.TryGetEnableTime(resourceType, out float time))
            {
                resourceTime = time;
            }
        }
        public void SetDisabledTime(ref float resourceTime, ResourceType resourceType)
        {
            if (resourceData.TryGetDisabledTime(resourceType, out float time))
            {
                resourceTime = time;
            }
        }
    }
}