using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class AgiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(AgiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "AGI";

        public override string skillDescription => "Detonate a light fire blast for <style=cIsDamage>300% damage</style>, applying <style=cIsDamage>burn</style>, " +
            $"and despositing <style=cIsDamage>blazing areas</style> nearby."; // for <style=cIsDamage>Stun</style> for a short duration.";

        public override string skillName => "Agi";

    }
}
