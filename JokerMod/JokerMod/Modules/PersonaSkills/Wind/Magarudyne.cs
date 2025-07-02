using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MagarudyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MagarudyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAGARUDYNE";

        public override string skillDescription => "Encompass yourself with 5 heavy wind cyclones, dealing <style=cIsDamage>800% damage</style> each, " +
            "inflicting <style=cIsDamage>swept</style>, and <style=cIsUtility>pushing</style> all nearby entities.";

        public override string skillName => "Magarudyne";

    }
}

