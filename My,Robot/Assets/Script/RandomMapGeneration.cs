/*	RandomMapGenerations.cs -- The script/algorithm for a procedural generation of the map's PoIs. They will be randomly placed throughout the map.
 */

using UnityEngine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic; 	//for lists
using Random = UnityEngine.Random;
using Assets.Script;

namespace Assets.RandomMapGeneration
{
	public class RandomMapGeneration : MonoBehaviour {
		/* Prefab Definition: */
		public GameObject tree;
		public GameObject rock;
		public GameObject food;

		/* Amount of resources we will be randomly spawning*/
		public int treelimit = 10;
		public int rocklimit = 10;
		public int foodlimit = 10;
		public int maxlimit = 10;

		public float xDis = .32f;
		public float yDis = .32f;
		public float minX = -2.72f;
		public float minY = -2.72f;
		public float maxX = 3.04f;
		public float maxY = 3.04f;

		private Transform mapHolder;
		private List <Vector3> mapCoordinates = new List <Vector3> ();


		/*Creates Coordinates for every tile in the map*/
		void CreateCoordinates()
		{
			mapCoordinates.Clear ();

			for(float x = minX; x <= maxX; x+= xDis)
			{
				for (float y = minY; y < maxY; y+= yDis){

					if(x < -1 || y < -1 || y > 1 || x > 1)
					mapCoordinates.Add (new Vector3 (x, y, 0f));
				}
			}
		}

		void CreateMap()
		{
			for (int x = 0; x < maxlimit; x++) {

				if (treelimit > 0) {
					CreateInstance (tree);
					treelimit--;
				}
				if (rocklimit > 0) {
					CreateInstance (rock);
					rocklimit--;
				}
				if (foodlimit > 0) {
					CreateInstance (food);
					foodlimit--;
				}


			}
		}
		void CreateInstance(GameObject type)
		{
			GameObject instance = null;
			Vector3 randomVector = RandomPosition ();
			instance = Instantiate (type) as GameObject;
            instance.transform.position = new Vector3(randomVector.x, randomVector.y, instance.transform.position.z);
			instance.transform.SetParent (transform);
		}


		Vector3 RandomPosition()
		{
			int randomIndex = Random.Range (0, mapCoordinates.Count);
			Vector3 randomPosition = mapCoordinates [randomIndex];

			mapCoordinates.RemoveAt (randomIndex);

			return randomPosition;
		}
		// Use this for initialization
		void Start () {
			CreateCoordinates ();

			CreateMap ();
			Debug.Log ("hello");
		}
		// Update is called once per frame
		void Update () {

		}
	}
}