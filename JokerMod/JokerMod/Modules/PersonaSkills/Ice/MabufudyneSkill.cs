using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MabufudyneSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MabufudyneState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "MABUFUDYNE";

        public override string skillDescription => "Hail down heavy ice particles all around for <style=cIsDamage>20x200% damage</style>, inflicting " +
            "<style=cIsDamage>frost</style> and <style=cIsDamage>freeze</style>.";

        public override string skillName => "Mabufudyne";

    }
}
