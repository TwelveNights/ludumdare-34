using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script
{
    public class Player : MonoBehaviour
    {
        public PointOfInterest currPointOfInterest;
        public Transform playerTransform;

        public ResourceDataCollection resources;

        // Use this for initialization
        void Start()
        {
            PointOfInterest.player = this;
            playerTransform = transform;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(currPointOfInterest.name);
        }

        public void EnterPOI(Transform loc, PointOfInterest poi)
        {
            playerTransform.position = loc.position;
            currPointOfInterest = poi;
        }
    }
}