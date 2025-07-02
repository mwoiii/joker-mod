using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaMasks {
    public class HighPixiePersona : PersonaBase {

        public override string personaNameToken => "HIGHPIXIE";

        public override string personaName => "High Pixie";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(DiaramaState));

        public override GameObject modelPrefab => null;

        public override JokerCatalog.DropTables dropTables => JokerCatalog.DropTables.Tier3 | JokerCatalog.DropTables.Tier4;

    }
}
