using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    [System.Serializable]
    public class ResourceDataCollection
    {
        public List<ResourceData> resources;

        public ResourceData this[string key]
        {
            get 
            {
                foreach (ResourceData resource in resources)
                {
                    if (resource.name == key)
                        return resource;
                }

                throw new NullReferenceException();
            }
            set
            {
                foreach (ResourceData resource in resources)
                {
                    if (resource.name == key)
                        resources[resources.IndexOf(resource)] = value;
                }

                throw new NullReferenceException();
            }
        }
    }


    [System.Serializable]
    public class ResourceData
    {
        public string name;
        public float resourceCount;
        public float resourceGatheringRate;
        public float resourceGatheringElapsedTime;
        public float resourceGatheringAmount;
        public float resourceMax;
    }
}
