using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Script.Modules
{
    [System.Serializable]
    public class ResourceCost
    {
        public string ResourceName;
        public float ResourceAmount;

    }



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
        public List<ResourceCost> CreationCosts;

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

        public bool CanBuild()
        {
            bool result = true;
            foreach(ResourceCost cost in CreationCosts)
            {
                result &= GameInfo.player.resources[cost.ResourceName].ResourceCount >= cost.ResourceAmount;
            }

            return result;
        }

        public bool Build()
        {
            if (!CanBuild()) return false;

            foreach (ResourceCost cost in CreationCosts)
            {
                GameInfo.player.resources[cost.ResourceName].AddResource(-cost.ResourceAmount);
            }

            return true;
        }
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
