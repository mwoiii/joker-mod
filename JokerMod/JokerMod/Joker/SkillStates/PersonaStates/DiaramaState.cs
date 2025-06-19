using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiaramaState : PersonaSkillBaseState {
        public override float spCost { get; } = 40f;

        private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulse healingPulse = new HealingPulse();
            healingPulse.healAmount = 200f + 10 * characterBody.level;
            healingPulse.origin = characterBody.corePosition;
            healingPulse.radius = 20f;
            healingPulse.effectPrefab = seekerVFX;
            healingPulse.fxScale = 1f;
            healingPulse.teamIndex = TeamIndex.Player;
            healingPulse.overShield = 0f;
            healingPulse.Fire();
        }
    }
}