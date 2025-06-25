using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MagaruSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MagaruState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MAGARU";

        public override string skillDescription => "Encompass yourself with 5 light wind cyclones, dealing <style=cIsDamage>300% damage</style> each, " +
            "inflicting <style=cIsDamage>Swept</style>, and <style=cIsUtility>pushing</style> all nearby entities.";

        public override string skillName => "Magaru";

    }
}

