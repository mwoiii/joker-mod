using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class LakshmiPersona : PersonaBase {

        public override string personaNameToken => "LAKSHMI";

        public override string personaName => "Lakshmi";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MediarahanState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6 | JokerCatalog.DropTables.Tier7;

        public override string calloutString => "Play_Joker_Voice_Lakshmi";
    }
}
