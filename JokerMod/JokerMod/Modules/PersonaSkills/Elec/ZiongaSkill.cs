using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class ZiongaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(ZiongaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "ZIONGA";

        public override string skillDescription => "Fire a medium electric beam for <style=cIsDamage>4x125% damage</style>, applying <style=cIsDamage>shock</style> " +
            $"and <style=cIsDamage>stun</style> for a duration.";

        public override string skillName => "Zionga";

    }
}
