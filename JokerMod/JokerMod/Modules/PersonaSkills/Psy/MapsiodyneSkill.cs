using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class MapsiodyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MapsiodyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAPSIODYNE";

        public override string skillDescription => "Emit a heavy psychokinetic burst in a <style=cIsUtility>large radius</style> for " +
            $"<style=cIsDamage>800% damage</style>, applying <style=cIsUtility>8-18 random effects</style>.";

        public override string skillName => "Mapsiodyne";

    }
}
