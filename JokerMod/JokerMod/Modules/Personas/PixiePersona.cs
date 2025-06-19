using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class PixiePersona : PersonaBase {

        public override string personaNameToken => "PIXIE";

        public override string personaName => "Pixie";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(DiaState));

        public override GameObject modelPrefab => null;

    }
}
