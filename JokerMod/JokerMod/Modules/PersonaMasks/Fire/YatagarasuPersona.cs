using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class YatagarasuPersona : PersonaBase {

        public override string personaNameToken => "YATAGARASU";

        public override string personaName => "Yatagarasu";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(AgidyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Fire;
    }
}
