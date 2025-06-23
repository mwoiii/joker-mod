using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class PsioSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(PsioState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "PSIO";

        public override string skillDescription => "Emit a medium psychokinetic burst for <style=cIsDamage>500% damage</style>, and apply " +
            $"<style=cIsUtility>5-10 debuffs</style> - or have a small chance to apply <style=cDeath>2-4 buffs</style>.";

        public override string skillName => "Psio";

    }
}
