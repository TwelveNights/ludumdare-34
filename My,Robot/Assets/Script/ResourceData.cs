using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

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
                    if (resource.Name == key)
                        return resource;
                }

                throw new NullReferenceException();
            }
            set
            {
                foreach (ResourceData resource in resources)
                {
                    if (resource.Name == key)
                        resources[resources.IndexOf(resource)] = value;
                }

                throw new NullReferenceException();
            }
        }

        public void UpdateUI()
        {
            Debug.Log("Holla");
            foreach (ResourceData res in resources)
                res.UpdateUI();
        }
    }


    [System.Serializable]
    public class ResourceData
    {
        public string Name;
        public float ResourceCount;
        public float ResourceGatheringRate;
        public float ResourceGatheringElapsedTime;
        public float ResourceGatheringAmount;
        public float ResourceMax;
        public Text UIText;

        public void UpdateUI()
        {
            UIText.text = ResourceCount + "/" + ResourceMax;
        }

        public void AddResource(float val)
        {
            ResourceCount += val;
            ResourceCount = Math.Min(ResourceCount, ResourceMax);
        }
    }
}
