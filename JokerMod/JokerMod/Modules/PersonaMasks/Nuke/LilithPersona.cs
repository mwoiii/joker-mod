using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class LilithPersona : PersonaBase {

        public override string personaNameToken => "LILITH";

        public override string personaName => "Lilith";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MafreidyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier6;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Nuke;
    }
}
