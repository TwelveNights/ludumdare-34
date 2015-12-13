using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Modules.UI
{
    class CloseButton : MonoBehaviour
    {
        public GameObject UIModule;

        public void Close()
        {
            UIModule.SetActive(false);
        }

        public void Hover()
        {
            transform.Translate(Vector3.up * 2);
        }
        public void UnHover()
        {
            transform.Translate(Vector3.down * 2);
        }
    }
}
