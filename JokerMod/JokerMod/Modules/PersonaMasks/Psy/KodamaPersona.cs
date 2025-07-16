using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KodamaPersona : PersonaBase {

        public override string personaNameToken => "KODAMA";

        public override string personaName => "Kodama";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(PsiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

        public override string calloutString => "Play_Joker_Voice_Kodama";
    }
}
