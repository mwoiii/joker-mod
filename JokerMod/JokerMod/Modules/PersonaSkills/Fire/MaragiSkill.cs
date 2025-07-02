using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaragiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaragiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MARAGI";

        public override string skillDescription => "Detonate 3 light fire blasts for <style=cIsDamage>300% damage</style> each, applying <style=cIsDamage>burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby.";

        public override string skillName => "Maragi";

    }
}
