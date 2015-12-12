using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script
{
    public class Player : MonoBehaviour
    {
        public PointOfInterest currPointOfInterest;

        public ResourceDataCollection resources;

        // Use this for initialization
        void Start()
        {
            PointOfInterest.player = this;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(currPointOfInterest.name);
        }

        public void EnterPOI(Transform loc, PointOfInterest poi)
        {
            transform.position = loc.position;
            currPointOfInterest = poi;
        }
    }
}