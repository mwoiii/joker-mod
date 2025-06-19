using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class DiarahanState : PersonaSkillBaseState {
        public override float spCost { get; } = 60f;

        private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulsePercentage healingPulse = new HealingPulsePercentage();
            healingPulse.healFlat = 0f;
            healingPulse.healFraction = 1f;
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