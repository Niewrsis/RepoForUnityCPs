using UnityEngine;
using UnityEngine.UI;
using ResourceSystem.Data;

namespace ResourceSystem
{
    public class ResourceViewService
    {
        private static ResourceViewService instance;
        public static ResourceViewService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceViewService();
                }

                return instance;
            }
        }

        private ResourceViewDataSO _viewData;
        private ResourceViewDataSO ViewData
        {
            get
            {
                if(_viewData == null)
                {
                    _viewData = Resources.Load("ResourceViewData") as ResourceViewDataSO;
                }
                return _viewData;
            }
        }
        public void SetEnabledIcon(Image resourceIcon, ResourceType resourceType)
        {
            if (ViewData.TryGetEnabledIcon(resourceType, out Sprite icon))
            {
                resourceIcon.sprite = icon;
            }
        }
        public void SetDisabledIcon(Image resourceIcon, ResourceType resourceType)
        {
            if (ViewData.TryGetDisabledIcon(resourceType, out Sprite icon))
            {
                resourceIcon.sprite = icon;
            }
        }
    }
}