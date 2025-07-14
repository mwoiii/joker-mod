using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.PersonaSkills;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JokerMod.Joker.SkillStates.PersonaStates {

    public class DiarahanState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.HealHeavy;

        public override float baseSPCost { get; } = 18f;

        private static GameObject seekerVFX = Addressables.LoadAssetAsync<GameObject>("RoR2/DLC2/Seeker/MeditateSuccessVFX.prefab").WaitForCompletion();

        protected override void ActivateSkill() {
            CharacterBody characterBody = GetComponent<CharacterBody>();
            HealingPulsePercentage healingPulse = new HealingPulsePercentage();
            healingPulse.healFraction = 1f;
            healingPulse.origin = characterBody.corePosition;
            healingPulse.radius = 15f;
            healingPulse.effectPrefab = seekerVFX;
            healingPulse.fxScale = 1f;
            healingPulse.teamIndex = characterBody.teamComponent.teamIndex;
            healingPulse.overShield = 0f;
            healingPulse.Fire();
        }
    }
}