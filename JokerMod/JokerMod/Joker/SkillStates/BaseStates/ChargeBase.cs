using System;
using EntityStates;
using RoR2;

namespace JokerMod.Joker.SkillStates.BaseStates {
    public abstract class ChargeBase : BaseSkillState {

        protected GenericSkill skill;

        protected abstract void AssignSkill();

        public override void OnEnter() {
            base.OnEnter();
            AssignSkill();
            ApplyRecharge(skill);
        }

        public static void ApplyRecharge(GenericSkill skill) {
            skill.stock = Math.Clamp(skill.stock + skill.rechargeStock, 1, skill.maxStock);
            skill.temporaryCooldownPenalty = 0f;
        }
    }
}