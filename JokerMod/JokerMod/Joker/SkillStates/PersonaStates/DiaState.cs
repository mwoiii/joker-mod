using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiaState : PersonaSkillBaseState {
        public override float spCost { get; } = 20f;

        private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulse healingPulse = new HealingPulse();
            healingPulse.healAmount = 90f + 5f * characterBody.level;
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