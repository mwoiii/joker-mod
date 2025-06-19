using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;


namespace JokerMod.Modules.PersonaSkills {
    public class EmptySkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(EmptyState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 0;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "EMPTY";

        public override string skillDescription => "<style=cStack>This skill is empty. Acquire a mask to fill this slot.</style>";

        public override string skillName => "Empty Skill Slot";

    }
}
