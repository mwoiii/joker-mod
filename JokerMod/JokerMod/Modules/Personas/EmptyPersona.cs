﻿using JokerMod.Joker.SkillStates.PersonaStates;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.Personas {
    public class EmptyPersona : PersonaBase {

        public override string personaNameToken => "EMPTY";

        public override string personaName => "Empty Skill Slot";

        public override SkillDef skillDef => JokerCatalog.GetSkillDefFromType(typeof(EmptyState));

        public override GameObject modelPrefab => null;

    }
}
