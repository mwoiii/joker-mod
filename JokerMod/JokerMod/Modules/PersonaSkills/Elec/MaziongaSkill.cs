using System;
using JokerMod.Joker.SkillStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class MaziongaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MaziongaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAZIONGA";

        public override string skillDescription => "Fire 3 medium electric beams for <style=cIsDamage>4x125% damage</style> each, applying <style=cIsDamage>Shock</style> " +
            $"and <style=cIsDamage>Stun</style> for a duration.";

        public override string skillName => "Mazionga";

    }
}
