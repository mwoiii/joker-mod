using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class ZiodyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(ZiodyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "ZIODYNE";

        public override string skillDescription => "Fire a heavy electric beam for <style=cIsDamage>8x100% damage</style>, applying <style=cIsDamage>shock</style> " +
            $"and <style=cIsDamage>stun</style> for a long duration.";

        public override string skillName => "Ziodyne";

    }
}
