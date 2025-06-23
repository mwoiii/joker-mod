using System;
using System.Linq;
using System.Collections.Generic;
using JokerMod.Modules.PersonaMasks;
using RoR2;
using RoR2.Skills;
using Newtonsoft.Json.Utilities;

namespace JokerMod.Modules {
    public static class JokerCatalog {

        private static Dictionary<ItemDef, PersonaDef> itemDefToPersonaDef = new Dictionary<ItemDef, PersonaDef>();

        private static Dictionary<string, PersonaDef> nameTokenToPersonaDef = new Dictionary<string, PersonaDef>();

        private static Dictionary<Type, SkillDef> typeToSkillDef = new Dictionary<Type, SkillDef>();

        public static List<ItemDef> itemDefs = new List<ItemDef>();

        // Level thresholds
        public const float tier1End = 7f;
        public const float tier2End = 11f;
        public const float tier3End = 14f;
        public const float tier4End = 17f;
        public const float tier5End = 20f;
        public const float tier6End = 24f;
        public const float tier7End = 28f;
        public const float tierAllEnd = 94f; // 94 is max level 

        public enum DropTables {
            Tier1 = 1,
            Tier2 = 2,
            Tier2Special = 4,
            Tier3 = 8,
            Tier3Special = 16,
            Tier4 = 32,
            Tier4Special = 64,
            Tier5 = 128,
            Tier5Special = 256,
            Tier6 = 512,
            Tier6Special = 1024,
            Tier7 = 2048,
            Tier7Special = 4096,
            Tier8 = 8192,   
            Tier8Special = 16384,
        }

        // STANDARD: Available from previous threshold, and decay in drop chance after their end threshold
        // SPECIAL: Slightly grow in drop chance up to their threshold, and decay in drop chance after their end threshold

        public static List<PersonaDef> tier1MaskList = new List<PersonaDef>();

        public static List<PersonaDef> tier2MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier2MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier3MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier3MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier4MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier4MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier5MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier5MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier6MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier6MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier7MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier7MaskListSpecial = new List<PersonaDef>();

        public static List<PersonaDef> tier8MaskList = new List<PersonaDef>();
        public static List<PersonaDef> tier8MaskListSpecial = new List<PersonaDef>();

        private static Dictionary<DropTables, List<PersonaDef>> tierMappings = new Dictionary<DropTables, List<PersonaDef>> {
                {  DropTables.Tier1, tier1MaskList },
                {  DropTables.Tier2, tier2MaskList },
                {  DropTables.Tier2Special, tier2MaskListSpecial },
                {  DropTables.Tier3, tier3MaskList },
                {  DropTables.Tier3Special, tier3MaskListSpecial },
                {  DropTables.Tier4, tier4MaskList },
                {  DropTables.Tier4Special, tier4MaskListSpecial },
                {  DropTables.Tier5, tier5MaskList },
                {  DropTables.Tier5Special, tier5MaskListSpecial },
                {  DropTables.Tier6, tier6MaskList },
                {  DropTables.Tier6Special, tier6MaskListSpecial },
                {  DropTables.Tier7, tier7MaskList },
                {  DropTables.Tier7Special, tier7MaskListSpecial },
                {  DropTables.Tier8, tier8MaskList },
                {  DropTables.Tier8Special, tier8MaskListSpecial },
        };

        public static PersonaDef RollForMask(float level) {
            // 90% change on-tier, 10% chance off-tier
            const float currentTierMult = 9f;

            float tier1Weight = RollFunc(level, tierAllEnd, tier1End);
            float tier2Weight = level <= tier2End ? RollFunc(level, 0f, tier1End) : RollFunc(level, tierAllEnd, tier2End);
            float tier3Weight = level <= tier3End ? RollFunc(level, 0f, tier2End) : RollFunc(level, tierAllEnd, tier3End);
            float tier4Weight = level <= tier4End ? RollFunc(level, 0f, tier3End) : RollFunc(level, tierAllEnd, tier4End);
            float tier5Weight = level <= tier5End ? RollFunc(level, 0f, tier4End) : RollFunc(level, tierAllEnd, tier5End);
            float tier6Weight = level <= tier6End ? RollFunc(level, 0f, tier5End) : RollFunc(level, tierAllEnd, tier6End);
            float tier7Weight = level <= tier7End ? RollFunc(level, 0f, tier6End) : RollFunc(level, tierAllEnd, tier7End);
            float tier8Weight = RollFunc(level, 0f, tierAllEnd);

            float sumWeights = tier1Weight + tier2Weight + tier3Weight + tier4Weight + tier5Weight + tier6Weight + tier7Weight + tier8Weight;
            switch (level) {
                case <= JokerCatalog.tier1End:
                    tier1Weight = (sumWeights - tier1Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier2End:
                    tier2Weight = (sumWeights - tier2Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier3End:
                    tier3Weight = (sumWeights - tier3Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier4End:
                    tier4Weight = (sumWeights - tier4Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier5End:
                    tier5Weight = (sumWeights - tier5Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier6End:
                    tier6Weight = (sumWeights - tier6Weight) * currentTierMult;
                    break;

                case <= JokerCatalog.tier7End:
                    tier7Weight = (sumWeights - tier7Weight) * currentTierMult;
                    break;

                default:
                    tier8Weight = (sumWeights - tier8Weight) * currentTierMult;
                    break;
            }

            List<PersonaDef> tier1Choices = tier1MaskList;

            List<PersonaDef> tier2Choices;
            if (level > tier1End) {
                tier2Choices = new List<PersonaDef>(tier2MaskList.Count + tier2MaskListSpecial.Count);
                tier2Choices.AddRange(tier2MaskList);
                tier2Choices.AddRange(tier2MaskListSpecial);
            } else {
                tier2Choices = tier2MaskListSpecial;
            }

            List<PersonaDef> tier3Choices;
            if (level > tier2End) {
                tier3Choices = new List<PersonaDef>(tier3MaskList.Count + tier3MaskListSpecial.Count);
                tier3Choices.AddRange(tier3MaskList);
                tier3Choices.AddRange(tier3MaskListSpecial);
            } else {
                tier3Choices = tier3MaskListSpecial;
            }

            List<PersonaDef> tier4Choices;
            if (level > tier3End) {
                tier4Choices = new List<PersonaDef>(tier4MaskList.Count + tier4MaskListSpecial.Count);
                tier4Choices.AddRange(tier4MaskList);
                tier4Choices.AddRange(tier4MaskListSpecial);
            } else {
                tier4Choices = tier4MaskListSpecial;
            }

            List<PersonaDef> tier5Choices;
            if (level > tier4End) {
                tier5Choices = new List<PersonaDef>(tier5MaskList.Count + tier5MaskListSpecial.Count);
                tier5Choices.AddRange(tier5MaskList);
                tier5Choices.AddRange(tier5MaskListSpecial);
            } else {
                tier5Choices = tier5MaskListSpecial;
            }

            List<PersonaDef> tier6Choices;
            if (level > tier5End) {
                tier6Choices = new List<PersonaDef>(tier6MaskList.Count + tier6MaskListSpecial.Count);
                tier6Choices.AddRange(tier6MaskList);
                tier6Choices.AddRange(tier6MaskListSpecial);
            } else {
                tier6Choices = tier6MaskListSpecial;
            }

            List<PersonaDef> tier7Choices;
            if (level > tier6End) {
                tier7Choices = new List<PersonaDef>(tier7MaskList.Count + tier7MaskListSpecial.Count);
                tier7Choices.AddRange(tier7MaskList);
                tier7Choices.AddRange(tier7MaskListSpecial);
            } else {
                tier7Choices = tier7MaskListSpecial;
            }

            List<PersonaDef> tier8Choices;
            if (level > tier7End) {
                tier8Choices = new List<PersonaDef>(tier8MaskList.Count + tier8MaskListSpecial.Count);
                tier8Choices.AddRange(tier8MaskList);
                tier8Choices.AddRange(tier8MaskListSpecial);
            } else {
                tier8Choices = tier8MaskListSpecial;
            }

            List<PersonaDef>[] choices = [tier1Choices, tier2Choices, tier3Choices, tier4Choices, tier5Choices, tier6Choices, tier7Choices, tier8Choices];
            float[] weights = [tier1Weight, tier2Weight, tier3Weight, tier4Weight, tier5Weight, tier6Weight, tier7Weight, tier8Weight];

            IEnumerable<object> selectedList = (IEnumerable<object>)Utils.RandomChoices(choices, weights);

            // failsafe 
            if (!selectedList.Any()) {
                Log.Warning("Selected Persona tier was empty! Selecting one from nearest populated tier...");
                
                int centerIndex = Array.IndexOf(choices, selectedList);
                int offset = 1;

                bool exhausted = false;
                while (!exhausted) {
                    if (centerIndex - offset < 0 && centerIndex + offset >= choices.Length) {
                        exhausted = true;
                        break;
                    }

                    if (centerIndex - offset >= 0 && choices[centerIndex - offset].Any()) {
                        return (PersonaDef)Utils.RandomChoice(choices[centerIndex - offset]);
                    }

                    if (centerIndex + offset < choices.Length && choices[centerIndex + offset].Any()) {
                        return (PersonaDef)Utils.RandomChoice(choices[centerIndex + offset]);
                    }

                    offset++;
                }

                Log.Error("All Persona tiers were empty!");
                return null;
            }

            return (PersonaDef)Utils.RandomChoice(selectedList);
        }

        private static float RollFunc(float level, float valueAtZero, float valueAtOne) {
            return (level - valueAtZero) / (valueAtOne - valueAtZero);
        }

        public static void AddPersona(PersonaDef personaDef) {
            itemDefToPersonaDef[personaDef.itemDef] = personaDef;
            nameTokenToPersonaDef[personaDef.personaNameToken] = personaDef;

            // assigning to the selected droptables
            foreach (KeyValuePair<DropTables, List<PersonaDef>> kvp in tierMappings) {
                if ((personaDef.dropTables & kvp.Key) == kvp.Key) {
                    kvp.Value.Add(personaDef);
                }
            }
        }

        public static void AddSkill(Type type, SkillDef skillDef) {
            typeToSkillDef[type] = skillDef;
        }

        public static PersonaDef GetPersonaFromItemDef(ItemDef itemDef) {
            return itemDefToPersonaDef[itemDef];
        }

        public static PersonaDef GetPersonaFromNameToken(string nameToken) {
            return nameTokenToPersonaDef[nameToken];
        }

        public static SkillDef GetSkillDefFromType(Type type) {
            return typeToSkillDef[type];
        }

        public static bool CheckIsMask(ItemDef itemDef) {
            return itemDefToPersonaDef.ContainsKey(itemDef);
        }
    }
}
