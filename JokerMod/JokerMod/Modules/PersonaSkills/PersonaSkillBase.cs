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

            SkillDef skillDef = Skills.CreateSkillDef(new SkillDefInfo {
                activationState = new SerializableEntityStateType(personaSkillState),
                activationStateMachineName = activationStateMachineName,
                baseMaxStock = baseMaxStock,
                baseRechargeInterval = 0f,
                beginSkillCooldownOnSkillEnd = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                fullRestockOnAssign = true,
                interruptPriority = InterruptPriority.PrioritySkill,
                isCombatSkill = isCombatSkill,
                mustKeyPress = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                skillIcon = icon,
                skillDescriptionToken = $"JOKER_SKILL_{skillNameToken}_DESCRIPTION",
                skillName = $"JOKER_SKILL_{skillNameToken}_NAME",
                skillNameToken = $"JOKER_SKILL_{skillNameToken}_NAME",
            });

            JokerCatalog.AddSkill(personaSkillState, skillDef);
        }
    }
}
