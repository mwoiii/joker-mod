using System;
using System.Collections.Generic;
using System.Text;
using EntityStates;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules.Personas;
using R2API;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills
{
    public class EihaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(EihaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => true;

        public override Sprite icon => null;

        public override string skillNameToken => "EIHA";

        public override string skillDescription => "Cast a detonating curse projectile, dealing <style=cIsDamage>400% damage</style> plus " +
            $"<style=cIsDamage>5% max health damage</style> to all enemies caught in the attack.";

        public override string skillName => "Eiha";

    }
}
