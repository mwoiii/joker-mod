using System;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.PersonaSkills;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class PersonaDef : ScriptableObject {

        public string personaNameToken;

        public SkillDef skillDef;

        public ItemDef itemDef;

        public GameObject modelPrefab;

        public JokerCatalog.DropTables dropTables;

        public float baseSPCost;

        public SkillTypes.SkillType skillType;

        public string calloutString;

        public static PersonaDef CreatePersonaDefFromInfo(PersonaDefInfo personaDefInfo) {
            PersonaDef personaDef = (PersonaDef)ScriptableObject.CreateInstance(typeof(PersonaDef));
            personaDef.name = personaDefInfo.personaNameToken;
            personaDef.personaNameToken = personaDefInfo.personaNameToken;
            personaDef.skillDef = personaDefInfo.skillDef;
            personaDef.itemDef = personaDefInfo.itemDef;
            personaDef.modelPrefab = personaDefInfo.modelPrefab;
            personaDef.dropTables = personaDefInfo.dropTables;
            personaDef.calloutString = personaDefInfo.calloutString;
            PersonaSkillBaseState skill = (PersonaSkillBaseState)Activator.CreateInstance(personaDef.skillDef.activationState.stateType);
            personaDef.baseSPCost = skill.baseSPCost;
            personaDef.skillType = skill.skillType;
            return personaDef;
        }
    }
}
