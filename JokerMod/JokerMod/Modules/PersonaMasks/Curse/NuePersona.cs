using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class NuePersona : PersonaBase {

        public override string personaNameToken => "NUE";

        public override string personaName => "Nue";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MaeihaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Curse;

    }
}
