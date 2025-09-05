using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaeihaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaeihaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAEIHA";

        public override string skillDescription => "Cast 3 light curse projectiles, each dealing <style=cIsDamage>300% damage</style> plus " +
            $"at least <style=cIsHealth>5% max health</style> damage. Applies up to <style=cIsHealth>10 stacks of permanent curse</style>.";

        public override string skillName => "Maeiha";

    }
}
