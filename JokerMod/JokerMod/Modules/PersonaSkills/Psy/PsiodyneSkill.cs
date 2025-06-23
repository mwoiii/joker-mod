using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class PsiodyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(PsiodyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "PSIODYNE";

        public override string skillDescription => "Emit a heavy psychokinetic burst for <style=cIsDamage>800% damage</style>, and apply " +
            $"<style=cIsUtility>8-15 debuffs</style> - or have a small chance to apply <style=cDeath>3-5 buffs</style>.";

        public override string skillName => "Psiodyne";

    }
}
