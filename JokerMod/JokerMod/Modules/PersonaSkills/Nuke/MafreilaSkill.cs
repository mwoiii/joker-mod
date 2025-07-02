using System;
using JokerMod.Joker.SkillStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MafreilaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MafreilaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAFREILA";

        public override string skillDescription => "Cast 3 medium nuke projectiles which detonate after 1 second for <style=cIsDamage>500% damage</style> each. Permanently " +
            "applies <style=cIsDamage>irradiated</style>, and applies <style=cIsDamage>weak</style> for 8 seconds.";

        public override string skillName => "Mafreila";

    }
}
