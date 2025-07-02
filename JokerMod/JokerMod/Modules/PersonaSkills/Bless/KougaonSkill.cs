using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class KougaonSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(KougaonState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "KOUGAON";

        public override string skillDescription => "Release an array of heavy bless particles, applying <style=cIsUtility>hallowed</style> for 16 seconds, before detonating " +
            "for <style=cIsDamage>100% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Kougaon";

    }
}
