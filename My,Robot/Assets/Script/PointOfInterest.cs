using UnityEngine;
using System.Collections;

public class PointOfInterest : MonoBehaviour {
    [SerializeField]
    private Transform m_PlayerObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	}

    void OnMouseDown()
    {
        m_PlayerObject.transform.position = transform.position;

    }
}
