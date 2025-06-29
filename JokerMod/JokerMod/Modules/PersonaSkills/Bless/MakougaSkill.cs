using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MakougaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MakougaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAKOUGA";

        public override string skillDescription => "Surround yourself with an array of medium bless particles, applying <style=cIsUtility>Hallowed</style> for 10 seconds, before detonating " +
            "for <style=cIsDamage>60% damage</style> each. Gain a <style=cIsUtility>random buff</style> for each enemy hit.";

        public override string skillName => "Makouga";

    }
}
