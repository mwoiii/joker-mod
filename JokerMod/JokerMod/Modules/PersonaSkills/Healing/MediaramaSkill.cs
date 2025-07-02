using System;
using JokerMod.Joker.SkillStates.PersonaStates;
using UnityEngine;

namespace JokerMod.Modules.PersonaSkills {
    public class MediaramaSkill : PersonaSkillBase {

        public override Type personaSkillState => typeof(MediaramaState);

        public override String activationStateMachineName => "Weapon";

        public override int baseMaxStock => 1;

        public override bool isCombatSkill => false;

        public override Sprite icon => null;

        public override string skillNameToken => "MEDIARAMA";

        public override string skillDescription => "<style=cIsHealing>Heal all allies</style> for <style=cIsHealing>200 HP</style>. " +
            $"Healing scales with the caster's level.";

        public override string skillName => "Mediarama";

    }
}
