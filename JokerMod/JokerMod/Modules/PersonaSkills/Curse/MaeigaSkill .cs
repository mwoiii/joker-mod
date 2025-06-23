using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MaeigaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaeigaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAEIGA";

        public override string skillDescription => "Cast 3 medium curse projectiles, each dealing <style=cIsDamage>500% damage</style> plus " +
            $"<style=cIsHealth>8% max health</style> damage. Applies up to <style=cIsHealth>20 stacks of permanent curse</style>.";

        public override string skillName => "Maeiga";

    }
}
