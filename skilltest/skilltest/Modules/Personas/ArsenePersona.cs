using System;
using System.Collections.Generic;
using System.Text;
using JokerMod.Joker.SkillStates.PersonaStates;
using R2API;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class ArsenePersona : PersonaBase {

        public override string personaNameToken => "ARSENE";

        public override string personaName => "Arsène";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EihaState));

        public override float spCost => 20f;

        public override GameObject modelPrefab => null;

    }
}
