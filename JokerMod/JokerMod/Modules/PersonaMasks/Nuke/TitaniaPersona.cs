using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class TitaniaPersona : PersonaBase {

        public override string personaNameToken => "TITANIA";

        public override string personaName => "Titania";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(FreidyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

    }
}
