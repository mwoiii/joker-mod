using EntityStates;
using RoR2;
using UnityEngine;
using System;
using UnityEngine.Networking;
using static EntityStates.Toolbot.ToolbotStanceBase;
using R2API;
using RoR2.Skills;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;


namespace JokerMod.Modules.PersonaSkills
{
    public class CancelSkill : PersonaSkillBase
    {

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
