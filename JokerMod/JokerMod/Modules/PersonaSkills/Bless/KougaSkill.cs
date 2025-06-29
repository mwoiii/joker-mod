using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class KougaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(KougaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "KOUGA";

        public override string skillDescription => "Release an array of medium bless particles, applying <style=cIsUtility>Hallowed</style> for 10 seconds, before detonating " +
            "for <style=cIsDamage>60% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Kouga";

    }
}
