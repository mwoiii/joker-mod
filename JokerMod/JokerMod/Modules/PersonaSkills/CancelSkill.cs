using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;


namespace JokerMod.Modules.PersonaSkills {
    public class CancelSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(CancelState);

        public override String activationStateMachineName => "Charge";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "CANCEL";

        public override string skillDescription => "Close the Persona menu.";

        public override string skillName => "Cancel";

    }
}
