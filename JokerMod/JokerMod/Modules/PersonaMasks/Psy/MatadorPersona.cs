using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks
{
    public class MatadorPersona : PersonaBase {

        public override string personaNameToken => "MATADOR";

        public override string personaName => "Matador";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(MapsiState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier2 | JokerCatalog.DropTables.Tier3;

    }
}
