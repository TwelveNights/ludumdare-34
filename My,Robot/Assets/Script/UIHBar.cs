using UnityEngine;
using System.Collections;

namespace Assets.Script
{
    public class UIHBar : MonoBehaviour
    {

        public RectTransform mask;
        public RectTransform img;

        public float m_OrigMaskHeight;
        public float m_ZeroMaskHeight;
        public float m_OrigImgHeight;


        void Awake()
        {
            m_OrigMaskHeight = mask.position.y;
            m_ZeroMaskHeight = mask.rect.height;
            m_OrigImgHeight = img.position.y;

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MoveBar(float perc)
        {
            float moveDelta = (m_ZeroMaskHeight * perc) / 45;

            mask.position = mask.position + Vector3.down * moveDelta;
            img.position = img.position + Vector3.up * moveDelta;
        }

        public void Reset()
        {
            mask.position = new Vector3(mask.position.x, m_OrigMaskHeight, mask.position.z);
            img.position = new Vector3(img.position.x, m_OrigImgHeight, img.position.z);
        }
    }
}