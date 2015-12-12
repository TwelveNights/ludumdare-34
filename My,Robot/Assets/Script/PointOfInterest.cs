using UnityEngine;
using System.Collections;

public class PointOfInterest : MonoBehaviour
{
    public string name;
    public bool initialPOI = false;

    // Use this for initialization
    void Start()
    {
        if (initialPOI)
            Player.EnterPOI(transform, this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Player.EnterPOI(transform, this);
    }
}
