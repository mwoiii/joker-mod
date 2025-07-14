using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class NekomataPersona : PersonaBase {

        public override string personaNameToken => "NEKOMATA";

        public override string personaName => "Nekomata";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MagaruState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

         
    }
}
