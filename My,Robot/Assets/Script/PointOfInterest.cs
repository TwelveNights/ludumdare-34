using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; 

namespace Assets.Script
{
    public class PointOfInterest : MonoBehaviour
    {
        public static Player player;

        public string name;
        public bool initialPOI = false;

        public List<string> resourceToModify = new List<string>();

        public List<POIAction> actions = new List<POIAction>();

        // Use this for initialization
        void Start()
        {
            if (initialPOI) player.EnterPOI(transform, this);
            //actions.AddRange(GetComponents<POIAction>());
        }

        // Update is called once per frame
        void Update()
        {
            if (player.currPointOfInterest == this) GatherResource();
        }

        protected void GatherResource()
        {
            foreach (string key in resourceToModify)
            {
                ResourceData resource = player.resources[key];

                if(resource.resourceGatheringElapsedTime >= resource.resourceGatheringRate)
                {
                    resource.resourceCount += resource.resourceGatheringAmount; //* >>location gathering modifier<< 
                    resource.resourceGatheringElapsedTime = 0;
                }
                else
                {
                    resource.resourceGatheringElapsedTime += Time.deltaTime;
                }
            }
        }

        void OnMouseDown()
        {
            if (player.currPointOfInterest != this)
            {
                player.EnterPOI(transform, this);
                foreach (string key in resourceToModify) player.resources[key].resourceGatheringElapsedTime = 0;
            }
            /*
            else
            {
                foreach(string key in resourceToModify)
                {
                    Player.resourceCount[key] += resourceModifiers[resourceToModify.IndexOf(key)];
                }
                foreach(POIAction action in actions)
                {
                    action.DoAction();
                }
            }*/
        }
    }
}