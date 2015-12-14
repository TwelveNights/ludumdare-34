using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Script.Modules.UI
{
    public class ModuleMenu : MonoBehaviour
    {
        private List<Module> availableModules;
        public List<ResourceModule> availableResourceModules;

        public GameObject UIModel;

        void Start()
        {
            availableModules = new List<Module>();
            availableModules.AddRange(availableResourceModules.Cast<Module>());

            for(int i = 0; i < Math.Min(3, availableModules.Count); i++)
            {
                Module currModule = availableModules[i];

                GameObject obj = Instantiate(UIModel, transform.position, Quaternion.identity) as GameObject; 
                RectTransform rect = obj.GetComponent<RectTransform>();
                rect.position = transform.position + Vector3.down + Vector3.down * rect.rect.height * i * 2;

                Text text = obj.GetComponentInChildren<Text>();
                text.text = currModule.Name;

                ModuleButton modButton = obj.GetComponent<ModuleButton>();

                modButton.module = currModule;
                modButton.menu = this;
    
                obj.transform.SetParent(transform);
            }
        }

        public void Remove(Module module)
        {
            availableModules.Remove(module);
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
