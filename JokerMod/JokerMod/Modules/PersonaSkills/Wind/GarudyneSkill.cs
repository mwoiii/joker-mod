using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class GarudyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(GarudyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "GARUDYNE";

        public override string skillDescription => "Summon a heavy wind cyclone for <style=cIsDamage>800% damage</style>, inflicting <style=cIsDamage>swept</style>, " +
            "and <style=cIsUtility>pushing</style> all nearby entities.";

        public override string skillName => "Garudyne";

    }
}
