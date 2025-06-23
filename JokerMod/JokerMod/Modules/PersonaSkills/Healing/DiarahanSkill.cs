using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class DiarahanSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(DiarahanState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "DIARAHAN";

        public override string skillDescription => "<style=cIsHealing>Heal yourself and all nearby allies</style> for <style=cIsHealing>100% HP</style>.";

        public override string skillName => "Diarahan";

    }
}
