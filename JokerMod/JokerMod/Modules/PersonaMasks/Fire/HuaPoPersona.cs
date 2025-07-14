using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class HuaPoPersona : PersonaBase {

        public override string personaNameToken => "HUAPO";

        public override string personaName => "Hua Po";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaragiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

         
    }
}
