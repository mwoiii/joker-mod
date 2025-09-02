using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ApsarasPersona : PersonaBase {

        public override string personaNameToken => "APSARAS";

        public override string personaName => "Apsaras";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(BufuState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

        public override string calloutString => "Play_Joker_Voice_Apsaras";
    }
}
