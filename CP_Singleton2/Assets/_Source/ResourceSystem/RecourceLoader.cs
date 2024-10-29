using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    public class RecourceLoader
    {
        private Dictionary<Type, ScriptableObject> _loadedResources;
        private static RecourceLoader _instance;
        public static RecourceLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RecourceLoader();
                }

                return _instance;
            }
        }
        public void LoadResource()
        {

        }
        public void UnloadResource(ResourceType resourceType)
        {

        }

        public bool TryGerResource<T>(out T data) where T : ScriptableObject
        {
            data = null;
            return false;
        }
    }
}