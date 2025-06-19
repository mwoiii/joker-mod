using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class SarasvatiPersona : PersonaBase {

        public override string personaNameToken => "SARASVATI";

        public override string personaName => "Sarasvati";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(DiarahanState));

        public override GameObject modelPrefab => null;

    }
}
