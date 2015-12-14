using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class POIAction : MonoBehaviour
    {

        public virtual void DoAction() {
            GameInfo.ActiveActions.Add(this);
        }

        public virtual void EndAction() { }
    }
}
