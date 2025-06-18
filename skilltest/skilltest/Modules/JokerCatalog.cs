using System;
using System.Collections.Generic;
using System.Text;
using JokerMod.Modules.Personas;
using RoR2;
using RoR2.Skills;

namespace JokerMod.Modules
{
    public static class JokerCatalog
    {

        private static Dictionary<ItemDef, PersonaDef> itemDefToPersonaDef = new Dictionary<ItemDef, PersonaDef>();

        private static Dictionary<Type, SkillDef> typeToSkillDef = new Dictionary<Type, SkillDef>();

        public static List<ItemDef> itemDefs = new List<ItemDef>();

        public static void AddPersona(PersonaDef personaDef) {
            itemDefToPersonaDef[personaDef.itemDef] = personaDef;
        }

        public static void AddSkill(Type type, SkillDef skillDef) {
            Log.Info($"Adding skill with type {type.ToString()}");
            typeToSkillDef[type] = skillDef;
        }

        public static PersonaDef GetPersonaFromItemDef(ItemDef itemDef)
        {
            return itemDefToPersonaDef[itemDef];
        }

        public static SkillDef GetSkillDefFromType(Type type) {
            Log.Info($"Returning {typeToSkillDef[type]}");
            return typeToSkillDef[type];
        }
    }
}
