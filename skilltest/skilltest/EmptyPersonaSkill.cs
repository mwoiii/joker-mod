using EntityStates;
using RoR2;
using UnityEngine;
using System;
using UnityEngine.Networking;
using static EntityStates.Toolbot.ToolbotStanceBase;
using R2API;
using RoR2.Skills;


namespace SkillTest.MyEntityStates {
    public class EmptyPersonaSkill : BaseState {

        public static SkillDef skillDef;

        static EmptyPersonaSkill() {
            LanguageAPI.Add("JOKER_SPECIAL_EMPTY_NAME", "Empty Skill Slot");
            LanguageAPI.Add("JOKER_SPECIAL_EMPTY_DESCRIPTION", $"<style=cStack>This skill is empty. Acquire a mask to fill this slot.</style>");

            skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(SkillTest.MyEntityStates.EmptyPersonaSkill));
            skillDef.activationStateMachineName = "Weapon";
            skillDef.baseMaxStock = 0;
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
            skillDef.stockToConsume = 0;
            skillDef.icon = null;
            skillDef.hideStockCount = true;
            skillDef.skillDescriptionToken = "JOKER_SPECIAL_EMPTY_DESCRIPTION";
            skillDef.skillName = "JOKER_SPECIAL_EMPTY_NAME";
            skillDef.skillNameToken = "JOKER_SPECIAL_EMPTY_NAME";

            ContentAddition.AddSkillDef(skillDef);
        }
    }
}
