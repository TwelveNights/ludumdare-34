using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.Script.DialogueSystem
{
    public class TextBox : MonoBehaviour
    {
        public Text TextObject;
        public GameObject TextDisplay;

        public string FullText;
        public string RenderedText;
        public List<string> Queue;
        [SerializeField]
        private int Timeout = 150;
        private int Counter;

        [SerializeField]
        private int Delay = 30;
        private int DelayCounter;
        [SerializeField]
        
        // Use this for initialization
        public void Start()
        {
            Counter = 0;
            DelayCounter = 0;
            Queue = new List<string>();

            Queue.Add("...................................................................");
            Queue.Add("");
            Queue.Add("Looks like it's finally done! Now, how does this thing turn on? she asked.");
            Queue.Add("I hope everything is connected properly... All these parts are hard to come by nowadays, she said.");
            Queue.Add("Oooh, I think it's working, she said.");
            Queue.Add("Hey there! It seems like you're awake, she said.");
            Queue.Add("Can you understand me? I was pretty sure nobody's better than me in the field of natural language processing, she said.");
            Queue.Add("My name's Lily, what's your name? Lily asked.");
            Queue.Add("");
            Queue.Add("...");
            Queue.Add("");
            Queue.Add("Oh wait, I guess there's no point in asking. Also, I don't really know how giving you a voice will work, but I'll check it out later.");
            Queue.Add("Anyways, I'll be happy to keep you around. Nobody else to have for company, otherwise, Lily said.");
            Queue.Add("Now - let's test this out! My first diary entry! Lily said.");
            Queue.Add("");
            Queue.Add("Begin Recording");
            Queue.Add("Entry 1: A Brand New Day - ID fff8b5f");
            Queue.Add("Hey there! This will be my first diary entry. Not much has changed in the last few months, but I began working on a few projects.");
            Queue.Add("The water collection system somehow manages to stay intact, with the help of a few minor repairs from time to time.");
            Queue.Add("Aside from that, I have enough electricity to kill off boredom and enough instant noodles to live comfortably, hehehe. The robot is finally complete, and I'll try to update as much as possible.");
            Queue.Add("");
            Queue.Add("This is Lily, April 10th.");
            Queue.Add("End Recording");
            Queue.Add("");
            Queue.Add("Maybe when I'm feeling up for it, I'll add some cool stuff to you, Lily said.");
            Queue.Add("That's all for today, though. I'm tired, Lily said.");
            Queue.Add("");
            Queue.Add("Go get me some food, or something. I'm starving.");

            GameInfo.player.GetComponent<MovementScript>().canMove = false;
            FullText = TextObject.text;
            RenderedText = "";
        }

        // Update is called once per frame
        public void Update()
        {
            if (Queue.Count == 0 && FullText == "" && RenderedText == "")
            {
                GameInfo.player.GetComponent<MovementScript>().canMove = true;
                TextDisplay.SetActive(false);
            }
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
        }

        // Fast-forwards text, or skips to next text in queue
        public void OnMouseDown()
        {
            DelayCounter = 0;
            Counter = 0;

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