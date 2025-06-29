using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class FreidyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(FreidyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "FREIDYNE";

        public override string skillDescription => "Cast a heavy nuke projectile which detonates after 1 second for <style=cIsDamage>8x100% damage</style>. Permanently " +
            "applies <style=cIsDamage>Irradiated</style>, and applies <style=cIsDamage>Weak</style> for 12 seconds.";

        public override string skillName => "Freidyne";

    }
}
