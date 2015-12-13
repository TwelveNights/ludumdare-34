using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script
{
    public class Player : MonoBehaviour
    {
        public PointOfInterest currPointOfInterest;

        public ResourceDataCollection resources;

        void Awake()
        {
            PointOfInterest.player = this;
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(currPointOfInterest.m_POIName);
        }

        public void EnterPOI(Transform loc, PointOfInterest poi)
        {
            transform.position = loc.position;
            currPointOfInterest = poi;
        }
    }
}