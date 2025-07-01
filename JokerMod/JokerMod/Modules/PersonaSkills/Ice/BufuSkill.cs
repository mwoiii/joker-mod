using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class BufuSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(BufuState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "BUFU";

        public override string skillDescription => "Hail down light ice particles in front for <style=cIsDamage>12x50% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style>.";

        public override string skillName => "Bufu";

    }
}
