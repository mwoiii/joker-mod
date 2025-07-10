using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class NagaPersona : PersonaBase {

        public override string personaNameToken => "NAGA";

        public override string personaName => "Naga";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(ZiongaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Elec;
    }
}
