using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; 

namespace Assets.Script
{
    public class PointOfInterest : MonoBehaviour
    {
        public string m_POIName;
        public bool initialPOI = false;

        public List<string> resourceToModify = new List<string>();

        public List<POIAction> actions = new List<POIAction>();

        public bool isResource;
        public int availableGathers;

        public AudioClip resourceGained;
        public AudioClip resourceDeplete;
        public AudioClip resourceHarvest;


        // Use this for initialization
        void Start()
        { 
            m_POIName = gameObject.name;
            if (initialPOI) GameInfo.player.EnterPOI(transform, this);
            actions.AddRange(GetComponents<POIAction>());
        }

        // Update is called once per frame
        void Update()
        {
            if (GameInfo.player.currPointOfInterest == this)
            {
                GatherResource();
            }
        }

        public void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject == GameInfo.player.gameObject)
            {
                if (GameInfo.player.currPointOfInterest != this)
                {
                    //GameInfo.EndAllActiveActions();
                    GameInfo.player.currPointOfInterest = this;
                    foreach (string key in resourceToModify) GameInfo.player.resources[key].ResourceGatheringElapsedTime = 0;

                    if(isResource)
                    {
                        AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                        audio.clip = resourceHarvest;
                        audio.loop = true;
                        audio.Play();
                    }

                    foreach (POIAction action in actions)
                    {
                        action.DoAction();
                    }
                }
            }
        }

        public void OnCollisionExit2D(Collision2D coll)
        {
            if (coll.gameObject == GameInfo.player.gameObject)
            {
                if (GameInfo.player.currPointOfInterest == this)
                {
                    GameInfo.player.currPointOfInterest = null;
                    foreach (POIAction action in actions)
                    {
                        action.EndAction();
                    } 
                    
                    if (isResource)
                    {
                        AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                        audio.loop = false;
                        audio.Stop();
                    }
                }
            }
        }


        protected void GatherResource()
        {
            foreach (string key in resourceToModify)
            {
                ResourceData resource = GameInfo.player.resources[key];

                if(resource.ResourceGatheringElapsedTime >= resource.ResourceGatheringRate)
                {
                    resource.AddResource(resource.ResourceGatheringAmount); //* >>location gathering modifier<< 
                    resource.ResourceGatheringElapsedTime = 0;

                    AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                    audio.clip = resourceGained;
                    audio.loop = false;
                    audio.Play();

                    if (availableGathers >= 0)
                    {
                        if (--availableGathers == 0)
                        {
                            audio.clip = resourceDeplete;
                            audio.Play();
                            Destroy(gameObject);
                        }
                    }
                }
                else
                {
                    resource.ResourceGatheringElapsedTime += Time.deltaTime;
                    AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();

                    if(!audio.isPlaying)
                    {
                        audio.clip = resourceHarvest;
                        audio.loop = true;
                        audio.Play();
                    }
                }
            }


        }

        /*void OnMouseDown()
        {
            if (GameInfo.player.currPointOfInterest != this)
            {
                GameInfo.EndAllActiveActions();
                GameInfo.player.EnterPOI(transform, this);
                foreach (string key in resourceToModify) GameInfo.player.resources[key].ResourceGatheringElapsedTime = 0;

                foreach (POIAction action in actions)
                {
                    action.DoAction();
                }
            }
        }*/
    }
}