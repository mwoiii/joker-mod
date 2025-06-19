using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class PersonaDef : ScriptableObject {

        public string personaNameToken;

        public SkillDef skillDef;

        public ItemDef itemDef;

        public GameObject modelPrefab;

        public static PersonaDef CreatePersonaDefFromInfo(PersonaDefInfo personaDefInfo) {
            PersonaDef personaDef = (PersonaDef)ScriptableObject.CreateInstance(typeof(PersonaDef));
            personaDef.name = personaDefInfo.personaNameToken;
            personaDef.personaNameToken = personaDefInfo.personaNameToken;
            personaDef.skillDef = personaDefInfo.skillDef;
            personaDef.itemDef = personaDefInfo.itemDef;
            personaDef.modelPrefab = personaDefInfo.modelPrefab;
            return personaDef;
        }
    }
}
