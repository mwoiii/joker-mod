using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MafreiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MafreiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAFREI";

        public override string skillDescription => "Cast 3 light nuke projectiles which detonate after 1 second for <style=cIsDamage>300% damage</style> each. Permanently " +
            "applies <style=cIsDamage>Irradiated</style>, and applies <style=cIsDamage>Weak</style> for 5 seconds.";

        public override string skillName => "Mafrei";

    }
}
