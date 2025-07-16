using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class RajaNagaPersona : PersonaBase {

        public override string personaNameToken => "RAJANAGA";

        public override string personaName => "Raja Naga";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(ZiodyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

        public override string calloutString => "Play_Joker_Voice_RajaNaga";
    }
}
