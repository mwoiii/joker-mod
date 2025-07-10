using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class WhiteRiderPersona : PersonaBase {

        public override string personaNameToken => "WHITERIDER";

        public override string personaName => "White Rider";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaeigaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Curse;

    }
}
