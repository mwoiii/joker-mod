using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class SarasvatiPersona : PersonaBase {

        public override string personaNameToken => "SARASVATI";

        public override string personaName => "Sarasvati";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(DiarahanState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

        public override string calloutString => "Play_Joker_Voice_Sarasvati";
    }
}
