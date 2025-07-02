using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Joker.SkillStates.BaseStates;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MediaramaState : PersonaSkillBaseState {
        public override float baseSPCost { get; } = 12f;

        private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            CharacterBody characterBody = GetComponent<CharacterBody>();

            foreach (TeamComponent teamMember in TeamComponent.GetTeamMembers(characterBody.teamComponent.teamIndex)) {
                HealingPulsePercentage healingPulse = new HealingPulsePercentage();
                healingPulse.healFlat = 200f + 10 * characterBody.level;
                healingPulse.origin = teamMember.body.corePosition;
                healingPulse.radius = 5f;
                healingPulse.effectPrefab = seekerVFX;
                healingPulse.fxScale = 0.333f;
                healingPulse.teamIndex = characterBody.teamComponent.teamIndex;
                healingPulse.overShield = 0f;
                healingPulse.Fire();
            }
        }
    }
}