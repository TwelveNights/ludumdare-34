using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public static PointOfInterest currPointOfInterest;
    public static Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currPointOfInterest.name);
    }

    public static void EnterPOI(Transform loc, PointOfInterest poi)
    {
        playerTransform.position = loc.position;
        currPointOfInterest = poi;
    }
}
