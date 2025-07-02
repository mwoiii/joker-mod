using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MediarahanSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MediarahanState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "MEDIARAHAN";

        public override string skillDescription => "<style=cIsHealing>Heal all allies</style> for <style=cIsHealing>100% HP</style>.";

        public override string skillName => "Mediarahan";

    }
}
