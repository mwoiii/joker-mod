using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class MapsiSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MapsiState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAPSI";

        public override string skillDescription => "Emit a light psychokinetic burst in a <style=cIsUtility>large radius</style> for " +
            $"<style=cIsDamage>300% damage</style>, and apply <style=cIsUtility>3-8 debuffs</style> - or have a small chance to apply <style=cDeath>1-3 buffs</style>.";

        public override string skillName => "Mapsi";

    }
}
