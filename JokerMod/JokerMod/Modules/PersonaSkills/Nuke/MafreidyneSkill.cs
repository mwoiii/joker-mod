using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MafreidyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MafreidyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAFREIDYNE";

        public override string skillDescription => "Cast 3 heavy nuke projectiles which detonate after 1 second for <style=cIsDamage>8x100% damage</style> each. Permanently " +
            "applies <style=cIsDamage>irradiated</style>, and applies <style=cIsDamage>weak</style> for 12 seconds.";

        public override string skillName => "Mafreidyne";

    }
}
