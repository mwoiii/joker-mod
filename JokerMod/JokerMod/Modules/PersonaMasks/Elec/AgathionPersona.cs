using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class AgathionPersona : PersonaBase {

        public override string personaNameToken => "AGATHION";

        public override string personaName => "Agathion";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(ZioState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

    }
}
