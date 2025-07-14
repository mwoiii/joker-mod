using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class BelialPersona : PersonaBase {

        public override string personaNameToken => "BELIAL";

        public override string personaName => "Belial";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EigaonState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;
    }
}
