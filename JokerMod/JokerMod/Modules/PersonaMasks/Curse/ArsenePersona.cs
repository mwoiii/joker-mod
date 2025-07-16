using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ArsenePersona : PersonaBase {

        public override string personaNameToken => "ARSENE";

        public override string personaName => "Arsène";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EihaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => 0;

        public override string calloutString => "Play_Joker_Voice_Arsene";
    }
}
