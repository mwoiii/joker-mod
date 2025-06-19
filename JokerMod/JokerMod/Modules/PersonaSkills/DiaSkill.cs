using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class DiaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(DiaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "DIA";

        public override string skillDescription => "<style=cIsHealing>Heal yourself and all nearby allies</style> for <style=cIsHealing>90 HP</style>. " +
            $"Healing scales with the caster's level.";

        public override string skillName => "Dia";

    }
}
