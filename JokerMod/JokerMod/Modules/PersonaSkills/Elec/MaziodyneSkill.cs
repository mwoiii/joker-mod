using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class MaziodyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaziodyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAZIODYNE";

        public override string skillDescription => "Fire 3 heavy electric beams for <style=cIsDamage>8x100% damage</style> each, applying <style=cIsDamage>Shock</style> " +
            $"and <style=cIsDamage>Stun</style> for a long duration.";

        public override string skillName => "Maziodyne";

    }
}
