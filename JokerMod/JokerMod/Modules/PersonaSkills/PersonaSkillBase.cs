using System;
using EntityStates;
using R2API;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public abstract class PersonaSkillBase {

        public SkillDef skillDef { get; private set; }

        public abstract Type personaSkillState { get; }

        public abstract int baseMaxStock { get; }

        public abstract String activationStateMachineName { get; }

        public abstract bool isCombatSkill { get; }

        public abstract Sprite icon { get; }

        public abstract string skillNameToken { get; }

        public abstract string skillDescription { get; }

        public abstract string skillName { get; }

        public virtual void Init() {
            CreateLang();
            CreateSkillDef();
        }

        private void CreateLang() {
            LanguageAPI.Add($"JOKER_SKILL_{skillNameToken}_NAME", skillName);
            LanguageAPI.Add($"JOKER_SKILL_{skillNameToken}_DESCRIPTION", skillDescription);
        }

        protected void CreateSkillDef() {

            skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(personaSkillState);
            skillDef.activationStateMachineName = activationStateMachineName;
            skillDef.baseMaxStock = baseMaxStock;
            skillDef.baseRechargeInterval = 0f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.PrioritySkill;
            skillDef.isCombatSkill = isCombatSkill;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            skillDef.icon = icon;
            skillDef.skillDescriptionToken = $"JOKER_SKILL_{skillNameToken}_DESCRIPTION";
            skillDef.skillName = $"JOKER_SKILL_{skillNameToken}_NAME";
            skillDef.skillNameToken = $"JOKER_SKILL_{skillNameToken}_NAME";

            JokerCatalog.AddSkill(personaSkillState, skillDef);
        }
    }
}
