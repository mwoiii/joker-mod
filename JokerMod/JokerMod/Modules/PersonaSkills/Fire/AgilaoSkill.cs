using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class AgilaoSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(AgilaoState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "AGILAO";

        public override string skillDescription => "Detonate a medium fire blast for <style=cIsDamage>4x125% damage</style>, applying <style=cIsDamage>burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby.";

        public override string skillName => "Agilao";

    }
}
