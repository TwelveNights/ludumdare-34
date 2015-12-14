using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Modules;

namespace Assets.Script
{
    public class Player : MonoBehaviour
    {
        public PointOfInterest currPointOfInterest;

        public ResourceDataCollection resources;

        private List<Module> attachedModules;

        void Awake()
        {
            GameInfo.player = this;
            
        }

        // Use this for initialization
        void Start()
        {
            attachedModules = new List<Module>();   
        }

        public void AttachModule(Module module)
        {
            attachedModules.Add(module);
            module.ApplyModule(this);
        }

        // Update is called once per frame
        void Update()
        {
           // Debug.Log(currPointOfInterest.m_POIName);
        }

        public void EnterPOI(Transform loc, PointOfInterest poi)
        {
            transform.position = loc.position;
            currPointOfInterest = poi;
        }
    }

    public static class GameInfo
    {
        public static Player player;
    }
}