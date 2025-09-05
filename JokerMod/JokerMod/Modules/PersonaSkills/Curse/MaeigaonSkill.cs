using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaeigaonSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaeigaonState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAEIGAON";

        public override string skillDescription => "Cast 3 heavy curse projectiles, each dealing <style=cIsDamage>800% damage</style> plus " +
            $"at least <style=cIsHealth>12% max health</style> damage. Applies up to <style=cIsHealth>35 stacks of permanent curse</style>.";

        public override string skillName => "Maeigaon";

    }
}
