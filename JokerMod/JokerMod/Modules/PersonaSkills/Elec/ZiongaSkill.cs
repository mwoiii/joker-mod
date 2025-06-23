using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class ZiongaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(ZiongaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "ZIONGA";

        public override string skillDescription => "Fire a medium electric beam for <style=cIsDamage>4x125% damage</style>, applying <style=cIsDamage>Shock</style> " +
            $"and <style=cIsDamage>Stun</style> for 6 seconds.";

        public override string skillName => "Zionga";

    }
}
