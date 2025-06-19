using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiaramaState : PersonaSkillStateBase {
        public override float spCost { get; } = 40f;

        public override void OnEnter() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulse healingPulse = new HealingPulse();
            healingPulse.healAmount = 200f + 10 * characterBody.level;
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