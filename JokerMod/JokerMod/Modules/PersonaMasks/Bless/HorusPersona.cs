using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class HorusPersona : PersonaBase {

        public override string personaNameToken => "HORUS";

        public override string personaName => "Horus";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(KougaonState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

        public override string calloutString => "Play_Joker_Voice_Horus";
    }
}
