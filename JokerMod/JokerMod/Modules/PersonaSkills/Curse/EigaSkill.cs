using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class EigaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(EigaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "EIGA";

        public override string skillDescription => "Cast a medium curse projectile, dealing <style=cIsDamage>500% damage</style> plus " +
            $"at least <style=cIsHealth>8% max health</style> damage. Applies up to <style=cIsHealth>20 stacks of permanent curse</style>.";

        public override string skillName => "Eiga";

    }
}
