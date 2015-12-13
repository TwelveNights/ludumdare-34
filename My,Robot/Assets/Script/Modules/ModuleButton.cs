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

        public void Press()
        {
            GameInfo.player.AttachModule(module);
            menu.Remove(module);

            
            Destroy(gameObject);
        }
    }
}
