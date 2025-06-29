using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MakouhaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MakouhaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAKOUHA";

        public override string skillDescription => "Surround yourself with an array of light bless particles, applying <style=cIsUtility>Hallowed</style> for 6 seconds, before detonating " +
            "for <style=cIsDamage>40% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Makouha";

    }
}
