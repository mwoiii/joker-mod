using JokerMod.Joker.SkillStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class PrincipalityPersona : PersonaBase {

        public override string personaNameToken => "PRINCIPALITY";

        public override string personaName => "Principality";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MakougaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier4 | JokerCatalog.DropTables.Tier5;

    }
}
