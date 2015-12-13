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
		public float minX = -4;
		public float minY = -4;
		public float maxX = 4;
		public float maxY = 4;

		private Transform mapHolder;
		private List <Vector3> mapCoordinates = new List <Vector3> ();


		/*Creates Coordinates for every tile in the map*/
		void CreateCoordinates()
		{
			mapCoordinates.Clear ();

			for(float x = minX; x <= maxX; x+= xDis)
			{
				for (float y = minY; y < maxY; y+= yDis){
					if (x <= minX+0.1 || x >= maxX-0.1 || y >= maxY-0.1 || y <= minY+0.1) {
						GameObject instance;
						instance = Instantiate (tree, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
						instance.transform.SetParent (transform);
					}

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
				}
				if (rocklimit > 0) {
					CreateInstance (rock);
				}
				if (foodlimit > 0) {
					CreateInstance (food);
				}


			}
		}
		void CreateInstance(GameObject type)
		{
			GameObject instance = null;
			Vector3 randomVector = RandomPosition ();
			instance = Instantiate (type, randomVector, Quaternion.identity) as GameObject;
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