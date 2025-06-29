using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MakougaonSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MakougaonState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAKOUGAON";

        public override string skillDescription => "Surround yourself with an array of heavy bless particles, applying <style=cIsUtility>Hallowed</style> for 16 seconds, before detonating " +
            "for <style=cIsDamage>100% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Makougaon";

    }
}
