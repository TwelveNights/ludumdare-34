using UnityEngine;
using System.Collections;

namespace Assets.Script.DialogueSystem
{
    public class LilyStatus : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D c)
        {
            if (c.collider.isTrigger)
            {
                return;
            }
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