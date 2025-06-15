using EntityStates;
using RoR2;
using UnityEngine;
using System;
using UnityEngine.Networking;
using static EntityStates.Toolbot.ToolbotStanceBase;
using R2API;
using RoR2.Skills;


namespace SkillTest.MyEntityStates {
    public class CancelPersonaSkill : BaseState {

        public static SkillDef skillDef;

        static CancelPersonaSkill() {
            LanguageAPI.Add("JOKER_SPECIAL_CANCEL_NAME", "Cancel");
            LanguageAPI.Add("JOKER_SPECIAL_CANCEL_DESCRIPTION", $"Close the Persona menu.");

            skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(SkillTest.MyEntityStates.CancelPersonaSkill));
            skillDef.activationStateMachineName = "Charge";
            skillDef.baseMaxStock = 1;
            skillDef.baseRechargeInterval = 0f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Any;
            skillDef.isCombatSkill = false;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_SPECIAL_CANCEL_DESCRIPTION";
            skillDef.skillName = "JOKER_SPECIAL_CANCEL_NAME";
            skillDef.skillNameToken = "JOKER_SPECIAL_CANCEL_NAME";

            ContentAddition.AddSkillDef(skillDef);
        }
    }
}
