using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class AngelPersona : PersonaBase {

        public override string personaNameToken => "ANGEL";

        public override string personaName => "Angel";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(KouhaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

        public override string calloutString => "Play_Joker_Voice_Angel";
    }
}
