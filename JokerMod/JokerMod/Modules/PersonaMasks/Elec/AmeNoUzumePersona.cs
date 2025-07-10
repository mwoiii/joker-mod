using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class AmeNoUzumePersona : PersonaBase {

        public override string personaNameToken => "AMENOUZUME";

        public override string personaName => "Ame-no-Uzume";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MazioState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Elec;
    }
}
