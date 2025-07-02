using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class FreiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(FreiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "FREI";

        public override string skillDescription => "Cast a light nuke projectile which detonates after 1 seconds for <style=cIsDamage>300% damage</style>. Permanently " +
            "applies <style=cIsDamage>irradiated</style>, and applies <style=cIsDamage>weak</style> for 5 seconds.";

        public override string skillName => "Frei";

    }
}
