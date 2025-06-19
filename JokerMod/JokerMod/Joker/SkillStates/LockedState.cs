using System;
using EntityStates;
//Since we are using effects from Commando's Barrage skill, we will also be using the associated namespace
//You can also use Addressables or LegacyResourcesAPI to load whichever effects you like
using EntityStates.Commando.CommandoWeapon;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class LockedState : BaseState {

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}