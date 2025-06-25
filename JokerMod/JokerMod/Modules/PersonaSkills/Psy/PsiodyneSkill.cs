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

        public override string skillDescription => "Emit a heavy psychokinetic burst for <style=cIsDamage>800% damage</style>, applying " +
            $"<style=cIsUtility>8-18 random effects</style>.";

        public override string skillName => "Psiodyne";

    }
}
