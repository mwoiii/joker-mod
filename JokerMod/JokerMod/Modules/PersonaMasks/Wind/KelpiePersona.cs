using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class KelpiePersona : PersonaBase {

        public override string personaNameToken => "KELPIE";

        public override string personaName => "Kelpie";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(GaruState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier1 | JokerCatalog.DropTables.Tier2;

    }
}
