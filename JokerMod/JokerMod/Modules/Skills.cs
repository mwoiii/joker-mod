using System;
using EntityStates;
using JokerMod.Modules.PersonaSkills;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules {


    /*
    public static class Skills {

    
        private static void InitPrimary() {

            LanguageAPI.Add("JOKER_PRIMARY_SLASH_FLURRY_NAME", "Slash Flurry");
            LanguageAPI.Add("JOKER_PRIMARY_SLASH_FLURRY_DESCRIPTION", $"Slash in a wide arc for <style=cIsDamage>120% damage</style>. Further attacks in the combo deal <style=cIsDamage>increased damage</style>, and unique combo finishers can be performed by using the <style=cIsUtility>Special skill</style>.");

            SkillDef skillDef = ScriptableObject.CreateInstance<SkillDef>();

            skillDef.activationState = new SerializableEntityStateType(typeof(SlashFlurry));
            skillDef.activationStateMachineName = "Weapon";
            
            //skillDef.baseMaxStock = 8;
            //skillDef.baseRechargeInterval = 4f;
            //skillDef.beginSkillCooldownOnSkillEnd = false;
            //skillDef.canceledFromSprinting = false;
            //skillDef.cancelSprintingOnActivation = false;
            //skillDef.fullRestockOnAssign = true;
            //skillDef.interruptPriority = InterruptPriority.Any;
            //skillDef.isCombatSkill = true;
            //skillDef.mustKeyPress = false;
            //skillDef.rechargeStock = 1;
            //skillDef.requiredStock = 1;
            //skillDef.stockToConsume = 1;
            
            skillDef.icon = null;
            skillDef.skillDescriptionToken = "JOKER_PRIMARY_SLASH_FLURRY_DESCRIPTION";
            skillDef.skillName = "JOKER_PRIMARY_SLASH_FLURRY_NAME";
            skillDef.skillNameToken = "JOKER_PRIMARY_SLASH_FLURRY_NAME";

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
            LanguageAPI.Add("JOKER_SECONDARY_FIRE_DESCRIPTION", $"<style=cIsUtility>Agile.</style> Fire a bullet for <style=cIsDamage>125% damage</style>. <style=cIsUtility>A bullet is restocked on kill.</style> Continue holding the skill to fire an additional burst, using all remaining bullets. <style=cIsDamage>The damage is proportional to the number of bullets used.</style>");

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
            skillDef.interruptPriority = InterruptPriority.PrioritySkill;
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
                $"Hold the skill to instead perform an <style=cIsDamage>All-Out Attack</style>, unleashing a flurry of <style=cIsDamage>80% damage slayer</style> " +
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
            skillDef.interruptPriority = InterruptPriority.PrioritySkill;
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

            skillDef.activationState = new SerializableEntityStateType(typeof(ChargeSpecial));
            skillDef.activationStateMachineName = "Charge";
            skillDef.baseMaxStock = 1;
            skillDef.baseRechargeInterval = 6f;
            skillDef.beginSkillCooldownOnSkillEnd = true;
            skillDef.canceledFromSprinting = false;
            skillDef.cancelSprintingOnActivation = false;
            skillDef.fullRestockOnAssign = true;
            skillDef.interruptPriority = InterruptPriority.PrioritySkill;
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
    */

    internal static class Skills {

        public static void AddPersonaSkills() {
            new EmptySkill().Init();
            new CancelSkill().Init();

            // Bless
            new KouhaSkill().Init();
            new MakouhaSkill().Init();
            new KougaSkill().Init();
            new MakougaSkill().Init();
            new KougaonSkill().Init();
            new MakougaonSkill().Init();

            // Curse
            new EihaSkill().Init();
            new MaeihaSkill().Init();
            new EigaSkill().Init();
            new MaeigaSkill().Init();
            new EigaonSkill().Init();
            new MaeigaonSkill().Init();

            // Fire
            new AgiSkill().Init();
            new MaragiSkill().Init();
            new AgilaoSkill().Init();
            new MaragionSkill().Init();
            new AgidyneSkill().Init();
            new MaragidyneSkill().Init();

            // Ice
            new BufuSkill().Init();
            new MabufuSkill().Init();
            new BufulaSkill().Init();
            new MabufulaSkill().Init();
            new BufudyneSkill().Init();
            new MabufudyneSkill().Init();

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
            new MaziodyneSkill().Init();

            // Nuke
            new FreiSkill().Init();
            new MafreiSkill().Init();
            new FreilaSkill().Init();
            new MafreilaSkill().Init();
            new FreidyneSkill().Init();
            new MafreidyneSkill().Init();

            // Psy
            new PsiSkill().Init();
            new MapsiSkill().Init();
            new PsioSkill().Init();
            new MapsioSkill().Init();
            new PsiodyneSkill().Init();
            new MapsiodyneSkill().Init();

            // Healing
            new DiaSkill().Init();
            new MediaSkill().Init();
            new DiaramaSkill().Init();
            new MediaramaSkill().Init();
            new DiarahanSkill().Init();
            new MediarahanSkill().Init();

        }

        #region genericskills
        public static void CreateSkillFamilies(GameObject targetPrefab) => CreateSkillFamilies(targetPrefab, SkillSlot.Primary, SkillSlot.Secondary, SkillSlot.Utility, SkillSlot.Special);
        /// <summary>
        /// Create in order the GenericSkills for the skillslots desired, and create skillfamilies for them.
        /// </summary>
        /// <param name="targetPrefab">Body prefab to add GenericSkills</param>
        /// <param name="slots">Order of slots to add to the body prefab.</param>
        public static void CreateSkillFamilies(GameObject targetPrefab, params SkillSlot[] slots) {
            SkillLocator skillLocator = targetPrefab.GetComponent<SkillLocator>();

            for (int i = 0; i < slots.Length; i++) {
                switch (slots[i]) {
                    case SkillSlot.Primary:
                        skillLocator.primary = CreateGenericSkillWithSkillFamily(targetPrefab, "Primary");
                        break;
                    case SkillSlot.Secondary:
                        skillLocator.secondary = CreateGenericSkillWithSkillFamily(targetPrefab, "Secondary");
                        break;
                    case SkillSlot.Utility:
                        skillLocator.utility = CreateGenericSkillWithSkillFamily(targetPrefab, "Utility");
                        break;
                    case SkillSlot.Special:
                        skillLocator.special = CreateGenericSkillWithSkillFamily(targetPrefab, "Special");
                        break;
                    case SkillSlot.None:
                        break;
                }
            }
        }

        public static void ClearGenericSkills(GameObject targetPrefab) {
            foreach (GenericSkill obj in targetPrefab.GetComponentsInChildren<GenericSkill>()) {
                UnityEngine.Object.DestroyImmediate(obj);
            }
        }

        public static GenericSkill CreateGenericSkillWithSkillFamily(GameObject targetPrefab, SkillSlot skillSlot, bool hidden = false) {
            SkillLocator skillLocator = targetPrefab.GetComponent<SkillLocator>();
            switch (skillSlot) {
                case SkillSlot.Primary:
                    return skillLocator.primary = CreateGenericSkillWithSkillFamily(targetPrefab, "Primary", hidden);
                case SkillSlot.Secondary:
                    return skillLocator.secondary = CreateGenericSkillWithSkillFamily(targetPrefab, "Secondary", hidden);
                case SkillSlot.Utility:
                    return skillLocator.utility = CreateGenericSkillWithSkillFamily(targetPrefab, "Utility", hidden);
                case SkillSlot.Special:
                    return skillLocator.special = CreateGenericSkillWithSkillFamily(targetPrefab, "Special", hidden);
                case SkillSlot.None:
                    Log.Error("Failed to create GenericSkill with skillslot None. If making a GenericSkill outside of the main 4, specify a familyName, and optionally a genericSkillName");
                    return null;
            }
            return null;
        }
        public static GenericSkill CreateGenericSkillWithSkillFamily(GameObject targetPrefab, string familyName, bool hidden = false) => CreateGenericSkillWithSkillFamily(targetPrefab, familyName, familyName, hidden);
        public static GenericSkill CreateGenericSkillWithSkillFamily(GameObject targetPrefab, string genericSkillName, string familyName, bool hidden = false) {
            GenericSkill skill = targetPrefab.AddComponent<GenericSkill>();
            skill.skillName = genericSkillName;
            skill.hideInCharacterSelect = hidden;

            SkillFamily newFamily = ScriptableObject.CreateInstance<SkillFamily>();
            (newFamily as ScriptableObject).name = targetPrefab.name + familyName + "Family";
            newFamily.variants = new SkillFamily.Variant[0];

            skill._skillFamily = newFamily;

            Content.AddSkillFamily(newFamily);
            return skill;
        }
        #endregion

        #region skillfamilies

        //everything calls this
        public static void AddSkillToFamily(SkillFamily skillFamily, SkillDef skillDef, UnlockableDef unlockableDef = null) {
            Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);

            skillFamily.variants[skillFamily.variants.Length - 1] = new SkillFamily.Variant {
                skillDef = skillDef,
                unlockableDef = unlockableDef,
                viewableNode = new ViewablesCatalog.Node(skillDef.skillNameToken, false, null)
            };
        }

        public static void AddSkillsToFamily(SkillFamily skillFamily, params SkillDef[] skillDefs) {
            foreach (SkillDef skillDef in skillDefs) {
                AddSkillToFamily(skillFamily, skillDef);
            }
        }

        public static void AddPrimarySkills(GameObject targetPrefab, params SkillDef[] skillDefs) {
            AddSkillsToFamily(targetPrefab.GetComponent<SkillLocator>().primary.skillFamily, skillDefs);
        }
        public static void AddSecondarySkills(GameObject targetPrefab, params SkillDef[] skillDefs) {
            AddSkillsToFamily(targetPrefab.GetComponent<SkillLocator>().secondary.skillFamily, skillDefs);
        }
        public static void AddUtilitySkills(GameObject targetPrefab, params SkillDef[] skillDefs) {
            AddSkillsToFamily(targetPrefab.GetComponent<SkillLocator>().utility.skillFamily, skillDefs);
        }
        public static void AddSpecialSkills(GameObject targetPrefab, params SkillDef[] skillDefs) {
            AddSkillsToFamily(targetPrefab.GetComponent<SkillLocator>().special.skillFamily, skillDefs);
        }

        /// <summary>
        /// pass in an amount of unlockables equal to or less than skill variants, null for skills that aren't locked
        /// <code>
        /// AddUnlockablesToFamily(skillLocator.primary, null, skill2UnlockableDef, null, skill4UnlockableDef);
        /// </code>
        /// </summary>
        public static void AddUnlockablesToFamily(SkillFamily skillFamily, params UnlockableDef[] unlockableDefs) {
            for (int i = 0; i < unlockableDefs.Length; i++) {
                SkillFamily.Variant variant = skillFamily.variants[i];
                variant.unlockableDef = unlockableDefs[i];
                skillFamily.variants[i] = variant;
            }
        }
        #endregion

        #region skilldefs
        public static SkillDef CreateSkillDef(SkillDefInfo skillDefInfo) {
            return CreateSkillDef<SkillDef>(skillDefInfo);
        }

        public static T CreateSkillDef<T>(SkillDefInfo skillDefInfo) where T : SkillDef {
            //pass in a type for a custom skilldef, e.g. HuntressTrackingSkillDef
            T skillDef = ScriptableObject.CreateInstance<T>();

            skillDef.skillName = skillDefInfo.skillName;
            (skillDef as ScriptableObject).name = skillDefInfo.skillName;
            skillDef.skillNameToken = skillDefInfo.skillNameToken;
            skillDef.skillDescriptionToken = skillDefInfo.skillDescriptionToken;
            skillDef.icon = skillDefInfo.skillIcon;

            skillDef.activationState = skillDefInfo.activationState;
            skillDef.activationStateMachineName = skillDefInfo.activationStateMachineName;
            skillDef.interruptPriority = skillDefInfo.interruptPriority;

            skillDef.baseMaxStock = skillDefInfo.baseMaxStock;
            skillDef.baseRechargeInterval = skillDefInfo.baseRechargeInterval;

            skillDef.rechargeStock = skillDefInfo.rechargeStock;
            skillDef.requiredStock = skillDefInfo.requiredStock;
            skillDef.stockToConsume = skillDefInfo.stockToConsume;

            skillDef.dontAllowPastMaxStocks = skillDefInfo.dontAllowPastMaxStocks;
            skillDef.beginSkillCooldownOnSkillEnd = skillDefInfo.beginSkillCooldownOnSkillEnd;
            skillDef.canceledFromSprinting = skillDefInfo.canceledFromSprinting;
            skillDef.forceSprintDuringState = skillDefInfo.forceSprintDuringState;
            skillDef.fullRestockOnAssign = skillDefInfo.fullRestockOnAssign;
            skillDef.resetCooldownTimerOnUse = skillDefInfo.resetCooldownTimerOnUse;
            skillDef.isCombatSkill = skillDefInfo.isCombatSkill;
            skillDef.mustKeyPress = skillDefInfo.mustKeyPress;
            skillDef.cancelSprintingOnActivation = skillDefInfo.cancelSprintingOnActivation;

            skillDef.keywordTokens = skillDefInfo.keywordTokens;

            JokerMod.Modules.Content.AddSkillDef(skillDef);


            return skillDef;
        }
        #endregion skilldefs
    }

    /// <summary>
    /// class for easily creating skilldefs with default values, and with a field for UnlockableDef
    /// </summary>
    internal class SkillDefInfo {
        public string skillName;
        public string skillNameToken;
        public string skillDescriptionToken;
        public string[] keywordTokens = Array.Empty<string>();
        public Sprite skillIcon;

        public SerializableEntityStateType activationState;
        public string activationStateMachineName;
        public InterruptPriority interruptPriority;

        public float baseRechargeInterval;
        public int baseMaxStock = 1;

        public int rechargeStock = 1;
        public int requiredStock = 1;
        public int stockToConsume = 1;

        public bool resetCooldownTimerOnUse = false;
        public bool fullRestockOnAssign = true;
        public bool dontAllowPastMaxStocks = false;
        public bool beginSkillCooldownOnSkillEnd = false;
        public bool mustKeyPress = false;

        public bool isCombatSkill = true;
        public bool canceledFromSprinting = false;
        public bool cancelSprintingOnActivation = true;
        public bool forceSprintDuringState = false;

        #region constructors
        public SkillDefInfo() { }
        /// <summary>
        /// Creates a skilldef for a typical primary.
        /// <para>combat skill, cooldown: 0, required stock: 0, InterruptPriority: Any</para>
        /// </summary>
        public SkillDefInfo(string skillName,
                            string skillNameToken,
                            string skillDescriptionToken,
                            Sprite skillIcon,

                            SerializableEntityStateType activationState,
                            string activationStateMachineName = "Weapon",
                            bool agile = false) {
            this.skillName = skillName;
            this.skillNameToken = skillNameToken;
            this.skillDescriptionToken = skillDescriptionToken;
            this.skillIcon = skillIcon;

            this.activationState = activationState;
            this.activationStateMachineName = activationStateMachineName;

            this.cancelSprintingOnActivation = !agile;

            if (agile) this.keywordTokens = new string[] { "KEYWORD_AGILE" };

            this.interruptPriority = InterruptPriority.Any;
            this.isCombatSkill = true;
            this.baseRechargeInterval = 0;

            this.requiredStock = 0;
            this.stockToConsume = 0;

        }
        #endregion construction complete
    }
}
