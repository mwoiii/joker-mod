using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.Merc;
using EntityStates.Huntress;
using System;
using UnityEngine.Networking;
using static MonoMod.InlineRT.MonoModRule;
using EntityStates.SiphonItem;

namespace JokerMod.Joker.SkillStates.BaseStates
{
    public abstract class ChargeBase : BaseSkillState
    {

        protected GenericSkill skill;

        protected abstract void AssignSkill();

        public override void OnEnter()
        {
            base.OnEnter();
            AssignSkill();
            skill.stock = Math.Clamp(skill.stock + skill.rechargeStock, 1, skill.maxStock);
            skill.temporaryCooldownPenalty = 0f;
        }
    }
}