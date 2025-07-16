using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class PhoenixPersona : PersonaBase {

        public override string personaNameToken => "PHOENIX";

        public override string personaName => "Phoenix";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(FreilaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

        public override string calloutString => "Play_Joker_Voice_Phoenix";
    }
}
