using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ByakkoPersona : PersonaBase {

        public override string personaNameToken => "BYAKKO";

        public override string personaName => "Byakko";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MabufulaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Ice;
    }
}
