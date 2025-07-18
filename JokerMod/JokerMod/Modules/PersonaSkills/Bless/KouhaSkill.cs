﻿using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class KouhaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(KouhaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "KOUHA";

        public override string skillDescription => "Release an array of light bless particles, applying <style=cIsUtility>hallowed</style> for 6 seconds, before detonating " +
            "for <style=cIsDamage>40% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Kouha";

    }
}
