using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class JackFrostPersona : PersonaBase {

        public override string personaNameToken => "JACKFROST";

        public override string personaName => "Jack Frost";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MabufuState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

         
    }
}
