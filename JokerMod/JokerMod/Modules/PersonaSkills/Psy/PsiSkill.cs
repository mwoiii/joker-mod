using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class PsiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(PsiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "PSI";

        public override string skillDescription => "Emit a light psychokinetic burst for <style=cIsDamage>300% damage</style>, and apply " +
            $"<style=cIsUtility>3-8 debuffs</style> - or have a small chance to apply <style=cDeath>1-3 buffs</style>.";

        public override string skillName => "Psi";

    }
}
