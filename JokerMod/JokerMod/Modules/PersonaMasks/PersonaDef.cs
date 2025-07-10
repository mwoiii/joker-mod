using System;
using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class PersonaDef : ScriptableObject {

        public enum SkillType {
            Phys,
            Gun,
            Fire,
            Ice,
            Elec,
            Wind,
            Psy,
            Nuke,
            Bless,
            Curse,
            Almighty,
            HealLight,
            HealMedium,
            HealHeavy,
            HealCleanse,
            BuffAtk,
            BuffDef,
            BuffSpd,
            BuffAll,
            DebuffAtk,
            DebuffDef,
            DebuffSpd,
            DebuffAll,
            Sleep,
            Forget,
            Charm,
            Passive,
        }

        public string personaNameToken;

        public SkillDef skillDef;

        public ItemDef itemDef;

        public GameObject modelPrefab;

        public JokerCatalog.DropTables dropTables;

        public float baseSPCost;

        public SkillType skillType;

        public static PersonaDef CreatePersonaDefFromInfo(PersonaDefInfo personaDefInfo) {
            PersonaDef personaDef = (PersonaDef)ScriptableObject.CreateInstance(typeof(PersonaDef));
            personaDef.name = personaDefInfo.personaNameToken;
            personaDef.personaNameToken = personaDefInfo.personaNameToken;
            personaDef.skillDef = personaDefInfo.skillDef;
            personaDef.itemDef = personaDefInfo.itemDef;
            personaDef.modelPrefab = personaDefInfo.modelPrefab;
            personaDef.dropTables = personaDefInfo.dropTables;
            personaDef.baseSPCost = ((PersonaSkillBaseState)Activator.CreateInstance(personaDef.skillDef.activationState.stateType)).baseSPCost;
            personaDef.skillType = personaDefInfo.skillType;
            return personaDef;
        }
    }
}
