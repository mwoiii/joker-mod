using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiarahanState : PersonaSkillStateBase {
        public override float spCost { get; } = 60f;

        public override void OnEnter() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulsePercentage healingPulse = new HealingPulsePercentage();
            healingPulse.healFlat = 0f;
            healingPulse.healFraction = 1f;
            healingPulse.origin = characterBody.corePosition;
            healingPulse.radius = 20f;
            healingPulse.effectPrefab = null;
            healingPulse.fxScale = 1f;
            healingPulse.teamIndex = TeamIndex.Player;
            healingPulse.overShield = 0f;
            healingPulse.Fire();
            base.OnEnter();
        }
    }
}