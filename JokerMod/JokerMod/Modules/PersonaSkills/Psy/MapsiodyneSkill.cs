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
            $"<style=cIsDamage>800% damage</style>, and apply <style=cIsUtility>8-15 debuffs</style> - or have a small chance to apply <style=cDeath>3-5 buffs</style>.";

        public override string skillName => "Mapsiodyne";

    }
}
