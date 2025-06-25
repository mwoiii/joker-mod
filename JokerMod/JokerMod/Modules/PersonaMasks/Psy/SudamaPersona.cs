using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class SudamaPersona : PersonaBase {

        public override string personaNameToken => "SUDAMA";

        public override string personaName => "Sudama";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(PsioState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

    }
}
