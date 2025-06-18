using System;
using System.Collections.Generic;
using System.Text;
using EntityStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Joker.SkillStates;
using R2API;
using UnityEngine.AddressableAssets;
using UnityEngine;
using RoR2.Skills;
using RoR2;
using JokerMod.Modules.PersonaSkills;

namespace JokerMod.Modules
{
    public static class Skills {
        public static void Init() {
            // InitPrimary();
            InitSecondary();
            InitUtility();
            InitSpecial();

            new EihaSkill().Init();
            new EmptySkill().Init();
            new CancelSkill().Init();
        }

        private static void InitPrimary() {

            LanguageAPI.Add("JOKER_PRIMARY_SLASHFLURRY_NAME", "Slash Flurry");
            LanguageAPI.Add("JOKER_PRIMARY_SLASHFLURRY_DESCRIPTION", $"Slash in a wide arc for <style=cIsDamage>120% damage</style>. Further attacks in the combo deal <style=cIsDamage>increased damage</style>, and unique combo finishers can be performed by using the <style=cIsUtility>Special skill</style>.");

            SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();

            mySkillDef.activationState = new SerializableEntityStateType(typeof(SlashFlurry));
            mySkillDef.activationStateMachineName = "Weapon";
            /*
            mySkillDef.baseMaxStock = 8;
            mySkillDef.baseRechargeInterval = 4f;
            mySkillDef.beginSkillCooldownOnSkillEnd = false;
            mySkillDef.canceledFromSprinting = false;
            mySkillDef.cancelSprintingOnActivation = false;
            mySkillDef.fullRestockOnAssign = true;
            mySkillDef.interruptPriority = InterruptPriority.Any;
            mySkillDef.isCombatSkill = true;
            mySkillDef.mustKeyPress = false;
            mySkillDef.rechargeStock = 1;
            mySkillDef.requiredStock = 1;
            mySkillDef.stockToConsume = 1;
            */
            mySkillDef.icon = null;
            mySkillDef.skillDescriptionToken = "JOKER_PRIMARY_SLASHFLURRY_DESCRIPTION";
            mySkillDef.skillName = "JOKER_PRIMARY_SLASHFLURRY_NAME";
            mySkillDef.skillNameToken = "JOKER_PRIMARY_SLASHFLURRY_NAME";

            ContentAddition.AddSkillDef(mySkillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.primary.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = mySkillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(mySkillDef.skillNameToken, false, null)
            };
        }

        private static void InitSecondary() {

            // We use LanguageAPI to add strings to the game, in the form of tokens
            // Please note that it is instead recommended that you use a language file.
            // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            LanguageAPI.Add("JOKER_SECONDARY_FIRE_NAME", "Fire!");
            LanguageAPI.Add("JOKER_SECONDARY_FIRE_DESCRIPTION", $"<style=cIsUtility>Agile.</style> Fire a bullet for <style=cIsDamage>150% damage</style>. <style=cIsUtility>A bullet is restocked on kill.</style> Continue holding the skill to fire an additional burst, using all remaining bullets. <style=cIsDamage>The damage is proportional to the number of bullets used.</style>");

            // Now we must create a SkillDef
            SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();

            //Check step 2 for the code of the CustomSkillsTutorial.MyEntityStates.SimpleBulletAttack class
            mySkillDef.activationState = new SerializableEntityStateType(typeof(ChargeSecondary));
            mySkillDef.activationStateMachineName = "Charge";
            mySkillDef.baseMaxStock = 8;
            mySkillDef.baseRechargeInterval = 4f;
            mySkillDef.beginSkillCooldownOnSkillEnd = false;
            mySkillDef.canceledFromSprinting = false;
            mySkillDef.cancelSprintingOnActivation = false;
            mySkillDef.fullRestockOnAssign = true;
            mySkillDef.interruptPriority = InterruptPriority.Any;
            mySkillDef.isCombatSkill = true;
            mySkillDef.mustKeyPress = true;
            mySkillDef.rechargeStock = 1;
            mySkillDef.requiredStock = 1;
            mySkillDef.stockToConsume = 1;
            // For the skill icon, you will have to load a Sprite from your own AssetBundle
            mySkillDef.icon = null;
            mySkillDef.skillDescriptionToken = "JOKER_SECONDARY_FIRE_DESCRIPTION";
            mySkillDef.skillName = "JOKER_SECONDARY_FIRE_NAME";
            mySkillDef.skillNameToken = "JOKER_SECONDARY_FIRE_NAME";

            // This adds our skilldef. If you don't do this, the skill will not work.
            ContentAddition.AddSkillDef(mySkillDef);

            // Now we add our skill to one of the survivor's skill families
            // You can change component.primary to component.secondary, component.utility and component.special
            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.secondary.skillFamily;

            // If this is an alternate skill, use this code.
            // Here, we add our skill as a variant to the existing Skill Family.
            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = mySkillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(mySkillDef.skillNameToken, false, null)
            };
        }

        private static void InitUtility() {

            LanguageAPI.Add("JOKER_UTILITY_PDASH_NAME", "Phantom Dash");
            LanguageAPI.Add("JOKER_UTILITY_PDASH_DESCRIPTION", $"Dash forward a short distance, <style=cIsUtility>gaining immunity for the duration</style>. " +
                $"Hold the skill to instead perform an <style=cIsDamage>All-Out Attack</style>, unleashing a flurry of <style=cIsDamage>90% damage slayer</style> " +
                $"attacks on all nearby enemies. <style=cIsUtility>Slain enemies have an increased chance of dropping a mask, and reduce the skill cooldown</style>.");

            SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();

            mySkillDef.activationState = new SerializableEntityStateType(typeof(ChargeUtility));
            mySkillDef.activationStateMachineName = "Charge";
            mySkillDef.baseMaxStock = 1;
            mySkillDef.baseRechargeInterval = 4f;
            mySkillDef.beginSkillCooldownOnSkillEnd = true;
            mySkillDef.canceledFromSprinting = false;
            mySkillDef.cancelSprintingOnActivation = false;
            mySkillDef.fullRestockOnAssign = true;
            mySkillDef.interruptPriority = InterruptPriority.Skill;
            mySkillDef.isCombatSkill = true;
            mySkillDef.mustKeyPress = true;
            mySkillDef.rechargeStock = 1;
            mySkillDef.requiredStock = 1;
            mySkillDef.stockToConsume = 1;
            mySkillDef.icon = null;
            mySkillDef.skillDescriptionToken = "JOKER_UTILITY_PDASH_DESCRIPTION";
            mySkillDef.skillName = "JOKER_UTILITY_PDASH_NAME";
            mySkillDef.skillNameToken = "JOKER_UTILITY_PDASH_NAME";

            ContentAddition.AddSkillDef(mySkillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.utility.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = mySkillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(mySkillDef.skillNameToken, false, null)
            };
        }

        private static void InitSpecial() {

            LanguageAPI.Add("JOKER_SPECIAL_PERSONA_NAME", "Persona!");
            LanguageAPI.Add("JOKER_SPECIAL_PERSONA_DESCRIPTION", $"Call forth your Persona, and cast a skill in exchange for either <style=cIsHealth>HP</style> or <style=cIsUtility>SP</style>.");

            SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();

            mySkillDef.activationState = new SerializableEntityStateType(typeof(UsePersonaSkill));
            mySkillDef.activationStateMachineName = "Charge";
            mySkillDef.baseMaxStock = 1;
            mySkillDef.baseRechargeInterval = 6f;
            mySkillDef.beginSkillCooldownOnSkillEnd = true;
            mySkillDef.canceledFromSprinting = false;
            mySkillDef.cancelSprintingOnActivation = false;
            mySkillDef.fullRestockOnAssign = true;
            mySkillDef.interruptPriority = InterruptPriority.Skill;
            mySkillDef.isCombatSkill = false;
            mySkillDef.mustKeyPress = true;
            mySkillDef.rechargeStock = 1;
            mySkillDef.requiredStock = 1;
            mySkillDef.stockToConsume = 1;
            mySkillDef.icon = null;
            mySkillDef.skillDescriptionToken = "JOKER_SPECIAL_PERSONA_DESCRIPTION";
            mySkillDef.skillName = "JOKER_SPECIAL_PERSONA_NAME";
            mySkillDef.skillNameToken = "JOKER_SPECIAL_PERSONA_NAME";

            ContentAddition.AddSkillDef(mySkillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.special.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = mySkillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(mySkillDef.skillNameToken, false, null)
            };
        }
    }
}
