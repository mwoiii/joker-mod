using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MabufuSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MabufuState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MABUFU";

        public override string skillDescription => "Hail down light ice particles all around for <style=cIsDamage>30x50% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style>.";

        public override string skillName => "Mabufu";

    }
}
