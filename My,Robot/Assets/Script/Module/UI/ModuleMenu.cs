using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Module.UI
{
    class ModuleMenu : MonoBehaviour
    {
        List<Module> availableModules;

        public Transform UIModel;

        public float a;

        void Start()
        {
            availableModules = new List<Module>();

            for(int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(UIModel, transform.position, Quaternion.identity) as GameObject; 
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.position = transform.position + Vector3.down * a + Vector3.down * rect.rect.height * i * 2;

                obj.transform.SetParent(transform);
            }
        }

        void Update()
        {
            foreach(Transform a in transform)
            {
                //DestroyObject(a.GetComponent<GameObject>());
            }
        }

    }
}
