using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class FreilaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(FreilaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "FREILA";

        public override string skillDescription => "Cast a medium nuke projectile which detonates after 1 second for <style=cIsDamage>500% damage</style>. Permanently " +
            "applies <style=cIsDamage>Irradiated</style>, and applies <style=cIsDamage>Weak</style> for 8 seconds.";

        public override string skillName => "Freila";

    }
}
