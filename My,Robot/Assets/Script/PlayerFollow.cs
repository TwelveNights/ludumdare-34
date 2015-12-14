using UnityEngine;
using System.Collections;
using Assets.Script;

public class PlayerFollow : MonoBehaviour {

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = GameInfo.player.transform.position;

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

	}
}
