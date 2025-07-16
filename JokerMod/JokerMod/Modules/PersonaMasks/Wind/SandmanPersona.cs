using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class SandmanPersona : PersonaBase {

        public override string personaNameToken => "SANDMAN";

        public override string personaName => "Sandman";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(GarulaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

        public override string calloutString => "Play_Joker_Voice_Sandman";
    }
}
