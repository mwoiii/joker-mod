using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class GaruSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(GaruState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "GARU";

        public override string skillDescription => "Summon a light wind cyclone for <style=cIsDamage>300% damage</style>, inflicting <style=cIsDamage>swept</style>, " +
            "and <style=cIsUtility>pushing</style> all nearby entities.";

        public override string skillName => "Garu";

    }
}
