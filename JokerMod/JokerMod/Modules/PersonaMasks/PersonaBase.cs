using R2API;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public abstract class PersonaBase {

        public PersonaDef personaDef { get; private set; }

        public ItemDef itemDef { get; private set; }

        public float baseSPCost { get; private set; }

        public abstract string personaNameToken { get; }

        public abstract string personaName { get; }

        public abstract SkillDef skillDef { get; }

        public abstract GameObject modelPrefab { get; }

        public abstract JokerCatalog.DropTables dropTables { get; }

        public virtual void Init() {
            CreateLang();
            CreatePersona();
        }

        protected void CreateLang() {
            LanguageAPI.Add($"JOKER_PERSONA_{personaNameToken}_NAME", personaName);
        }

        protected void CreatePersona() {
            personaDef = PersonaDef.CreatePersonaDefFromInfo(new PersonaDefInfo {
                personaNameToken = personaNameToken,
                skillDef = skillDef,
                itemDef = itemDef,
                modelPrefab = modelPrefab,
                dropTables = dropTables
            });

            itemDef = ScriptableObject.CreateInstance<ItemDef>();
            itemDef._itemTierDef = Asset.maskTierDef;
            itemDef.name = $"JOKER_PERSONA_{personaNameToken}_NAME";
            itemDef.nameToken = $"JOKER_PERSONA_{personaNameToken}_NAME";
            itemDef.descriptionToken = skillDef.skillDescriptionToken;
            itemDef.pickupToken = skillDef.skillDescriptionToken;
            itemDef.loreToken = skillDef.skillDescriptionToken;
            itemDef.canRemove = false;
            itemDef.hidden = true;
            itemDef.pickupIconSprite = null; // weaponDef.icon;
            itemDef.requiredExpansion = null;
            itemDef.tags = new ItemTag[6] {
                ItemTag.AIBlacklist,
                ItemTag.BrotherBlacklist,
                ItemTag.CannotCopy,
                ItemTag.CannotDuplicate,
                ItemTag.CannotSteal,
                ItemTag.WorldUnique
            };
            itemDef.unlockableDef = null;
            itemDef.pickupModelPrefab = Asset.maskPrefab;

            personaDef.itemDef = itemDef;

            ContentPacks.itemDefs.Add(itemDef);

            // temporary
            // ItemAPI.Add(new CustomItem(itemDef, new ItemDisplayRuleDict(null)));

            JokerCatalog.AddPersona(personaDef);

            /*
            Hunk.logbookBlacklist.Add(itemDef);
            if ((bool)modelPrefab) {
                HunkAssets.ConvertAllRenderersToHopooShader(modelPrefab);
            }
            */
        }
    }
}
