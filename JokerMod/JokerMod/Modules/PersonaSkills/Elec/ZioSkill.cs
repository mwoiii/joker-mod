using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class ZioSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(ZioState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "ZIO";

        public override string skillDescription => "Fire a light electric beam for <style=cIsDamage>300% damage</style>, applying <style=cIsDamage>Shock</style> " +
            $"and <style=cIsDamage>Stun</style> for a short duration.";

        public override string skillName => "Zio";

    }
}
