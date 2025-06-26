using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaragionSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaragionState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MARAGILAO";

        public override string skillDescription => "Detonate 3 medium fire blasts for <style=cIsDamage>4x125% damage</style> each, applying <style=cIsDamage>Burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby.";

        public override string skillName => "Maragilao";

    }
}
