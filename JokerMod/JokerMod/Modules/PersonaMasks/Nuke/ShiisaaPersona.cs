using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class ShiisaaPersona : PersonaBase {

        public override string personaNameToken => "SHIISAA";

        public override string personaName => "Shiisaa";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(FreiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

        public override PersonaDef.SkillType skillType => PersonaDef.SkillType.Nuke;
    }
}
