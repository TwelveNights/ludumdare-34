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

        public GameObject UIModel;

        public float a;

        void Start()
        {
            availableModules = new List<Module>();
            GameObject test = Instantiate(UIModel, transform.position + Vector3.down * a, Quaternion.identity) as GameObject;

            test.transform.SetParent(transform);
        }

        void Update()
        {
            foreach(Transform a in transform)
            {
                DestroyObject(a.GetComponent<GameObject>());
            }
        }

    }
}
