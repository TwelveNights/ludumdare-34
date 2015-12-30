using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Script.DialogueSystem;

namespace Assets.Script
{

    public class TextDisplayDefaults : MonoBehaviour
    {
        [SerializeField]
        public GameObject TextDisplay;
        public Text text;

        void OnCollisionEnter2D(Collision2D coll)
        {
            TextBox t = text.GetComponent<TextBox>();
            if (t.Queue.Count == 0 && t.FullText == "" && t.RenderedText == "") {
                t.Add("I don't have much to talk about at the moment... sorry!");
            }

            GameInfo.player.GetComponent<MovementScript>().canMove = false;
            TextDisplay.SetActive(true);
        }


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }

}