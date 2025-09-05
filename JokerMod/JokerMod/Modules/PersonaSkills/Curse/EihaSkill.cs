using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class EihaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(EihaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "EIHA";

        public override string skillDescription => "Cast a light curse projectile, dealing <style=cIsDamage>300% damage</style> plus " +
            $"at least <style=cIsHealth>5% max health</style> damage. Applies up to <style=cIsHealth>10 stacks of permanent curse</style>.";

        public override string skillName => "Eiha";

    }
}
