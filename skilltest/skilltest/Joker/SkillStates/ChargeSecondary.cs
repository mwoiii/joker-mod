using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.Merc;
using EntityStates.Huntress;
using System;
using UnityEngine.Networking;
using static MonoMod.InlineRT.MonoModRule;
using EntityStates.SiphonItem;
using JokerMod.Joker.SkillStates.BaseStates;

namespace JokerMod.Joker.SkillStates
{
    public class ChargeSecondary : ChargeBase
    {

        private const float BURST_THRESHOLD = 0.5f;

        protected override void AssignSkill()
        {
            skill = skillLocator.secondary;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Fire nextState = new Fire();
            EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(nextState);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!isAuthority || IsKeyDownAuthority() && fixedAge < BURST_THRESHOLD)
            {
                return;
            }

            if (fixedAge >= BURST_THRESHOLD && skill.stock >= 1)
            {
                FireBurst nextState = new FireBurst();
                EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(nextState);
                outer.SetNextStateToMain();
            }

            outer.SetNextStateToMain();
        }
    }
}