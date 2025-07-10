using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public struct PersonaDefInfo {

        public string personaNameToken;

        public SkillDef skillDef;

        public ItemDef itemDef;

        public GameObject modelPrefab;

        public JokerCatalog.DropTables dropTables;

        public PersonaDef.SkillType skillType;
    }
}
