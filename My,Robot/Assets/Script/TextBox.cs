using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.Script
{
    public class TextBox : MonoBehaviour
    {
        private Text TextObject;
        [SerializeField]
        private string FullText;
        [SerializeField]
        private string RenderedText;
        private List<string> Queue;
        [SerializeField]
        private int Timeout = 150;
        private int Counter;
        [SerializeField]
        private int Delay = 30;
        private int DelayCounter;
        [SerializeField]
        GameObject TextDisplay;

        // Use this for initialization
        public void Start()
        {
            Counter = 0;
            DelayCounter = 0;
            Queue = new List<string>();
            Queue.Add("One");
            Queue.Add("Two");
            Queue.Add("SAJd;fosklhgnf;dsakbj'kdcnb;kfdbdfgjdsklfsfj'ldskfjds;kfj;ds");
            TextObject = gameObject.GetComponent<Text>();
            FullText = TextObject.text;
            RenderedText = "";
        }

        // Update is called once per frame
        public void Update()
        {
            if (FullText != "") {
                if (Delay == DelayCounter) {
                    RenderedText += FullText[0].ToString();
                    ChangeTextBox();
                    FullText = FullText.Substring(1);
                    DelayCounter = 0;
                }
                    else DelayCounter++;
            }

            else
            { 
                if (Counter == Timeout)
                {
                    TextSwap();
                    Counter = 0;
                }

                else Counter++;
            }

            if (Queue.Count == 0 && RenderedText == "" && FullText == "")
            {
                TextDisplay.SetActive(false);
            }
        }

        // Fast-forwards text, or skips to next text in queue
        public void OnMouseDown()
        {
            if (FullText != "")
            {
                Debug.Log("FullText: " + FullText);
                RenderedText += FullText;
                FullText = "";
                ChangeTextBox();
            }

            else TextSwap();
        }

        // Adds a new element to the TextBox Queue
        public void Add(string s)
        {
            Queue.Add(s);
        }

        // Changes the TextObject's text to RenderedText
        private void ChangeTextBox()
        {
            TextObject.text = RenderedText;
        }

        // Prepares the next line of code to render
        private void TextSwap()
        {
            if (Queue.Count != 0)
            {
                FullText = Queue[0];
                Queue.RemoveAt(0);
            }

            RenderedText = "";
            ChangeTextBox();
        }
    }
}