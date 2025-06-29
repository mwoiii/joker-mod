using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class MakamiPersona : PersonaBase {

        public override string personaNameToken => "MAKAMI";

        public override string personaName => "Makami";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MafreiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

    }
}
