using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class MithrasPersona : PersonaBase {

        public override string personaNameToken => "MITHRAS";

        public override string personaName => "Mithras";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MafreilaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Nuke;
    }
}
