using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class SkadiPersona : PersonaBase {

        public override string personaNameToken => "SKADI";

        public override string personaName => "Skadi";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaeigaonState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;
    }
}
