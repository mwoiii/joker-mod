using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiaState : PersonaSkillStateBase {
        public override float spCost { get; } = 20f;

        public override void OnEnter() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulse healingPulse = new HealingPulse();
            healingPulse.healAmount = 90f + 5f * characterBody.level;
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