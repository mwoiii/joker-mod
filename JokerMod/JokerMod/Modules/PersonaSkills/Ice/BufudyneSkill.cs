using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class BufudyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(BufudyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "BUFUDYNE";

        public override string skillDescription => "Hail down heavy ice particles in front for <style=cIsDamage>8x200% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style> and <style=cIsDamage>freeze</style>.";

        public override string skillName => "Bufudyne";

    }
}
