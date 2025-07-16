using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KushiMitamaPersona : PersonaBase {

        public override string personaNameToken => "KUSHIMITAMA";

        public override string personaName => "Kushi Mitama";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MediaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

        public override string calloutString => "Play_Joker_Voice_KushiMitama";
    }
}
