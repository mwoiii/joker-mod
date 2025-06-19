using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class HighPixiePersona : PersonaBase {

        public override string personaNameToken => "HIGH_PIXIE";

        public override string personaName => "High Pixie";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(DiaramaState));

        public override GameObject modelPrefab => null;

    }
}
