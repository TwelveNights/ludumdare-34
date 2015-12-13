using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    /// <summary>
    /// Module Action, when clicked should trigger the UI
    /// system for adding, modifying, selecting, etc of 
    /// Modules for the robot.
    /// </summary>
    public class ModuleAction : POIAction
    {
        public GameObject UIModule;


        void Start()
        {
            UIModule.SetActive(false);
        }

        public override void DoAction()
        {
            UIModule.SetActive(true);
           // UIModule.GetComponent<Text
            
            base.DoAction();
        }
    }
}
