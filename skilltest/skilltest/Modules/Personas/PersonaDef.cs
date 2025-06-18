using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RoR2.Skills;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Joker.SkillStates;
using RoR2;

namespace JokerMod.Modules.Personas
{
    public class PersonaDef : ScriptableObject {

        public SkillDef skillDef;

        public ItemDef itemDef;

        public float spCost = 4f;

        public GameObject modelPrefab;

        public static PersonaDef CreatePersonaDefFromInfo(PersonaDefInfo personaDefInfo) {
            PersonaDef personaDef = (PersonaDef)ScriptableObject.CreateInstance(typeof(PersonaDef));
            personaDef.skillDef = personaDefInfo.skillDef;
            personaDef.itemDef = personaDefInfo.itemDef;
            personaDef.spCost = personaDefInfo.spCost;
            personaDef.modelPrefab = personaDefInfo.modelPrefab;
            return personaDef;
        }
    }
}
