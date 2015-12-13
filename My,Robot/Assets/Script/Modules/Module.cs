using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Script.Modules
{
    /// <summary>
    /// Modules modify
    /// - Resource Gathering Speed
    /// - Resource Gathering Amount
    /// - Movement
    /// </summary>
    [System.Serializable]
    public class Module
    {
        public enum ModifierType { Adittive, Multiplicative, Subtractive, Divisive };
    
        public string Name;

        public float Modifier;
        public ModifierType ValModType;
    
        protected virtual float ModifyValue(float val)
        {
            switch (ValModType)
            {
                case ModifierType.Adittive:
                    val += Modifier;
                    break;
                case ModifierType.Multiplicative:
                    val *= Modifier;
                    break;
                case ModifierType.Subtractive:
                    val -= Modifier;
                    break;
                case ModifierType.Divisive:
                    val /= Modifier;
                    break;
                default:
                    break;
            }

            return val;
        }

        public virtual void ApplyModule(Player player) { }
    }

    [System.Serializable]
    public class ResourceModule : Module
    {
        public enum ResourceModifierType { GatheringAmount, GatheringRate, ResourceMax }

        public String TargetResource;
        public ResourceModifierType ResModType;


        public override void ApplyModule(Player player)
        {
            ResourceDataCollection resources = player.resources;

            switch (ResModType)
            {
                case ResourceModifierType.GatheringAmount:
                    resources[TargetResource].ResourceGatheringAmount = ModifyValue(resources[TargetResource].ResourceGatheringAmount);
                    break;
                case ResourceModifierType.GatheringRate:
                    resources[TargetResource].ResourceGatheringRate = ModifyValue(resources[TargetResource].ResourceGatheringRate);
                    break;
                case ResourceModifierType.ResourceMax:
                    resources[TargetResource].ResourceMax = ModifyValue(resources[TargetResource].ResourceMax);
                    break;
                default:
                    break;
            }
        }
    }
}
