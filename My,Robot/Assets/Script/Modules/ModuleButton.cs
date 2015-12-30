using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.Modules.UI;
using UnityEngine;

namespace Assets.Script.Modules
{
    public class ModuleButton : MonoBehaviour
    {
        public Module module;
        public ModuleMenu menu;

        public float shakeTime;
        [SerializeField]
        private float currShakeTime;

        public List<Vector2> ShakePositions;
        [SerializeField]
        private bool isShaking = false;

        public Vector2 origPos;

        public AudioClip failedSound;
        public AudioClip donModule;

        public GameObject infoButton;
        public GameObject textBox;

        public void Press()
        {
            if(module.Build())
            {
                AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                audio.loop = false;
                audio.clip = donModule;
                audio.Play();
                BuildModule();
            }
            else if(!isShaking)
            {
                origPos = GetComponent<RectTransform>().position;
                isShaking = true;

                AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                audio.loop = false;
                audio.clip = failedSound;
                audio.Play();
            }
            else
            {
                AudioSource audio = GameInfo.player.GetComponentInChildren<AudioSource>();
                audio.loop = false;
                audio.clip = failedSound;
                audio.Play();
            }
        }

        public void Hover()
        {
            Debug.Log(":ASDASD:");
            infoButton = Instantiate(textBox, transform.position, Quaternion.identity) as GameObject;
            infoButton.transform.Translate(new Vector3(160, -40, 0));

            UnityEngine.UI.Text text = infoButton.GetComponentInChildren<UnityEngine.UI.Text>();
            text.text = module.CreationCosts[0].ResourceName + ": " + module.CreationCosts[0].ResourceAmount;

            infoButton.transform.SetParent(transform.parent);
        }

        public void UnHover()
        {
            Destroy(infoButton);
        }

        public void Update()
        {
            if(isShaking)
            {
                if (currShakeTime >= shakeTime)
                {
                    isShaking = false;
                    currShakeTime = 0f;
                }
                else
                {

                    float sectionAllocatedTime = shakeTime/ (ShakePositions.Count + 1);
                    Vector2 currPos = GetComponent<RectTransform>().position;

                    Vector2 targetPos;
                    int ndex = (int)Math.Floor(currShakeTime / sectionAllocatedTime);


                    Vector2 moveDelta;




                    if (ndex >= ShakePositions.Count) targetPos = origPos;
                    else targetPos = origPos + ShakePositions[ndex];

                    moveDelta = (targetPos - currPos);
                    moveDelta.Normalize();
                    moveDelta *= sectionAllocatedTime;

                    Vector2 appliedMove = currPos + moveDelta;
                    GetComponent<RectTransform>().position = new Vector3(appliedMove.x, appliedMove.y, GetComponent<RectTransform>().position.z);

                    currShakeTime += Time.deltaTime;
                }
            }
        }

        protected void BuildModule()
        {
            GameInfo.player.AttachModule(module);
            menu.Remove(module);


            Destroy(gameObject);
        }
    }
}
