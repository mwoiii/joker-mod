using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class ArsenePersona : PersonaBase {

        public override string personaNameToken => "ARSENE";

        public override string personaName => "Arsène";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EihaState));

        public override GameObject modelPrefab => null;

    }
}
