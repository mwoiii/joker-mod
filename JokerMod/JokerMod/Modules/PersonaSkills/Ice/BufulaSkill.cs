using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class BufulaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(BufulaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "BUFULA";

        public override string skillDescription => "Hail down medium ice particles in front for <style=cIsDamage>10x100% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style>.";

        public override string skillName => "Bufula";

    }
}
