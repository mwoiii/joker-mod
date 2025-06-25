using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MazioSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MazioState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAZIO";

        public override string skillDescription => "Fire 3 light electric beams for <style=cIsDamage>300% damage</style> each, applying <style=cIsDamage>Shock</style> " +
            $"and <style=cIsDamage>Stun</style> for a short duration.";

        public override string skillName => "Mazio";

    }
}
