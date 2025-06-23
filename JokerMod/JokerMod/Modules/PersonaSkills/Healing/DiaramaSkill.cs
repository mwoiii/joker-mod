using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class DiaramaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(DiaramaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "DIARAMA";

        public override string skillDescription => "<style=cIsHealing>Heal yourself and all nearby allies</style> for <style=cIsHealing>200 HP</style>. " +
            $"Healing scales with the caster's level.";

        public override string skillName => "Diarama";

    }
}
