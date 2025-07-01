using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MabufulaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MabufulaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MABUFULA";

        public override string skillDescription => "Hail down medium ice particles all around for <style=cIsDamage>25x100% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style>.";

        public override string skillName => "Mabufula";

    }
}
