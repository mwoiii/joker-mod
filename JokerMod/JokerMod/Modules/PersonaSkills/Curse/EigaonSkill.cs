using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class EigaonSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(EigaonState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "EIGAON";

        public override string skillDescription => "Cast a heavy curse projectile, dealing <style=cIsDamage>800% damage</style> plus " +
            $"<style=cIsHealth>12% max health</style> damage. Applies up to <style=cIsHealth>35 stacks of permanent curse</style>.";

        public override string skillName => "Eigaon";

    }
}
