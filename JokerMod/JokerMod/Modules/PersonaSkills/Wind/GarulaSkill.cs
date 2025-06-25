using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class GarulaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(GarulaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "GARULA";

        public override string skillDescription => "Summon a medium wind cyclone for <style=cIsDamage>500% damage</style>, inflicting <style=cIsDamage>Swept</style>, " +
            "and <style=cIsUtility>pushing</style> all nearby entities.";

        public override string skillName => "Garula";

    }
}
