using UnityEngine;
using System.Collections;

namespace Assets.Script.DialogueSystem
{

    public class TextDisplayDefaults : MonoBehaviour
    {
        public GameObject TextDisplay;

        void OnCollisionEnter2D(Collision2D coll)
        {
            TextDisplay.SetActive(true);
        }


        // Use this for initialization
        void Start()
        {
            TextDisplay.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }

}