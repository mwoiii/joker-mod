using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class AgidyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(AgidyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "AGIDYNE";

        public override string skillDescription => "Detonate a heavy fire blast for <style=cIsDamage>8x100% damage</style>, applying <style=cIsDamage>Burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby.";

        public override string skillName => "Agidyne";

    }
}
