using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class FortunaPersona : PersonaBase {

        public override string personaNameToken => "FORTUNA";

        public override string personaName => "Fortuna";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(GarudyneState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier5 | JokerCatalog.DropTables.Tier6;

    }
}
