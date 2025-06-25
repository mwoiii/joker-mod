using System;
using System.Collections.Generic;
using EntityStates;
using JokerMod.Joker.SkillStates;
using JokerMod.Modules.PersonaSkills;
using R2API;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules {
    public static class Skills {
        internal static List<SkillDef> skillDefs = new List<SkillDef>();

        public static void Init() {
            // InitPrimary();
            InitSecondary();
            InitUtility();
            InitSpecial();

            new EmptySkill().Init();
            new CancelSkill().Init();

            // Curse
            new EihaSkill().Init();
            new MaeihaSkill().Init();
            new EigaSkill().Init();
            new MaeigaSkill().Init();
            new EigaonSkill().Init();
            new MaeigaonSkill().Init();

            // Wind
            new GaruSkill().Init();
            new MagaruSkill().Init();
            new GarulaSkill().Init();
            new MagarulaSkill().Init();
            new GarudyneSkill().Init();
            new MagarudyneSkill().Init();

            // Elec
            new ZioSkill().Init();
            new MazioSkill().Init();
            new ZiongaSkill().Init();
            new MaziongaSkill().Init();
            new ZiodyneSkill().Init();
            new MaziodyneSkill().Init(); ;

            // Psy
            new PsiSkill().Init();
            new MapsiSkill().Init();
            new PsioSkill().Init();
            new MapsioSkill().Init();
            new PsiodyneSkill().Init();
            new MapsiodyneSkill().Init();

            // Healing
            new DiaSkill().Init();
            new DiaramaSkill().Init();
            new DiarahanSkill().Init();

        }

        private static void InitPrimary() {

            LanguageAPI.Add("JOKER_PRIMARY_SLASHFLURRY_NAME", "Slash Flurry");
            LanguageAPI.Add("JOKER_PRIMARY_SLASHFLURRY_DESCRIPTION", $"Slash in a wide arc for <style=cIsDamage>120% damage</style>. Further attacks in the combo deal <style=cIsDamage>increased damage</style>, and unique combo finishers can be performed by using the <style=cIsUtility>Special skill</style>.");

            SkillDef skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(SlashFlurry));
            skillDef.activationStateMachineName = "Weapon";
            /*
            skillDef.baseMaxStock = 8;
            skillDef.baseRechargeInterval = 4f;
            skillDef.beginSkillCooldownOnSkillEnd = false;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Any;
            skillDef.isCombatSkill = true;
            skillDef.mustKeyPress = false;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            */
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_PRIMARY_SLASHFLURRY_DESCRIPTION";
            skillDef.skillName = "JOKER_PRIMARY_SLASHFLURRY_NAME";
            skillDef.skillNameToken = "JOKER_PRIMARY_SLASHFLURRY_NAME";

            skillDefs.Add(skillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.primary.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = skillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(skillDef.skillNameToken, false, null)
            };
        }

        private static void InitSecondary() {

            // We use LanguageAPI to add strings to the game, in the form of tokens
            // Please note that it is instead recommended that you use a language file.
            // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
            LanguageAPI.Add("JOKER_SECONDARY_FIRE_NAME", "Fire!");
            LanguageAPI.Add("JOKER_SECONDARY_FIRE_DESCRIPTION", $"<style=cIsUtility>Agile.</style> Fire a bullet for <style=cIsDamage>150% damage</style>. <style=cIsUtility>A bullet is restocked on kill.</style> Continue holding the skill to fire an additional burst, using all remaining bullets. <style=cIsDamage>The damage is proportional to the number of bullets used.</style>");

            // Now we must create a SkillDef
            SkillDef skillDef = ScriptableObject.CreateInstance<SkillDef>();

            //Check step 2 for the code of the CustomSkillsTutorial.MyEntityStates.SimpleBulletAttack class
            skillDef.activationState = new SerializableEntityStateType(typeof(ChargeSecondary));
            skillDef.activationStateMachineName = "Charge";
            skillDef.baseMaxStock = 8;
            skillDef.baseRechargeInterval = 4f;
            skillDef.beginSkillCooldownOnSkillEnd = false;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Any;
            skillDef.isCombatSkill = true;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            // For the skill icon, you will have to load a Sprite from your own AssetBundle
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_SECONDARY_FIRE_DESCRIPTION";
            skillDef.skillName = "JOKER_SECONDARY_FIRE_NAME";
            skillDef.skillNameToken = "JOKER_SECONDARY_FIRE_NAME";

            // This adds our skilldef. If you don't do this, the skill will not work.
            skillDefs.Add(skillDef);

            // Now we add our skill to one of the survivor's skill families
            // You can change component.primary to component.secondary, component.utility and component.special
            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.secondary.skillFamily;

            // If this is an alternate skill, use this code.
            // Here, we add our skill as a variant to the existing Skill Family.
            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = skillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(skillDef.skillNameToken, false, null)
            };
        }

        private static void InitUtility() {

            LanguageAPI.Add("JOKER_UTILITY_PDASH_NAME", "Phantom Dash");
            LanguageAPI.Add("JOKER_UTILITY_PDASH_DESCRIPTION", $"Dash forward a short distance, <style=cIsUtility>gaining immunity for the duration</style>. " +
                $"Hold the skill to instead perform an <style=cIsDamage>All-Out Attack</style>, unleashing a flurry of <style=cIsDamage>90% damage slayer</style> " +
                $"attacks on all nearby enemies. <style=cIsUtility>Slain enemies have an increased chance of dropping a mask, and reduce the skill cooldown</style>.");

            SkillDef skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(ChargeUtility));
            skillDef.activationStateMachineName = "Charge";
            skillDef.baseMaxStock = 1;
            skillDef.baseRechargeInterval = 4f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Skill;
            skillDef.isCombatSkill = true;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_UTILITY_PDASH_DESCRIPTION";
            skillDef.skillName = "JOKER_UTILITY_PDASH_NAME";
            skillDef.skillNameToken = "JOKER_UTILITY_PDASH_NAME";

            skillDefs.Add(skillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.utility.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = skillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(skillDef.skillNameToken, false, null)
            };
        }

        private static void InitSpecial() {

            LanguageAPI.Add("JOKER_SPECIAL_PERSONA_NAME", "Persona!");
            LanguageAPI.Add("JOKER_SPECIAL_PERSONA_DESCRIPTION", $"Call forth your Persona, and cast a skill in exchange for either <style=cIsHealth>HP</style> or <style=cIsUtility>SP</style>.");

            SkillDef skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(OverrideMenu));
            skillDef.activationStateMachineName = "Charge";
            skillDef.baseMaxStock = 1;
            skillDef.baseRechargeInterval = 6f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.Skill;
            skillDef.isCombatSkill = false;
            skillDef.mustKeyPress = true;
            skillDef.rechargeStock = 1;
            skillDef.requiredStock = 1;
            skillDef.stockToConsume = 1;
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_SPECIAL_PERSONA_DESCRIPTION";
            skillDef.skillName = "JOKER_SPECIAL_PERSONA_NAME";
            skillDef.skillNameToken = "JOKER_SPECIAL_PERSONA_NAME";

            skillDefs.Add(skillDef);

            SkillLocator skillLocator = Asset.mercBodyPrefab.GetComponent<SkillLocator>();
            SkillFamily skillFamily = skillLocator.special.skillFamily;

            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = skillDef,
                unlockableName = "",
                viewableNode = new ViewablesCatalog.Node(skillDef.skillNameToken, false, null)
            };
        }
    }
}
