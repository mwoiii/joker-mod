using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaragidyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaragidyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MARAGIDYNE";

        public override string skillDescription => "Detonate 3 heavy fire blasts for <style=cIsDamage>8x100% damage</style> each, applying <style=cIsDamage>Burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby.";

        public override string skillName => "Maragidyne";

    }
}
