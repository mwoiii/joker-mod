using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class MapsioSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MapsioState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAPSIO";

        public override string skillDescription => "Emit a medium psychokinetic burst in a <style=cIsUtility>large radius</style> for " +
            $"<style=cIsDamage>500% damage</style>, applying <style=cIsUtility>5-12 random effects</style>.";

        public override string skillName => "Mapsio";

    }
}
