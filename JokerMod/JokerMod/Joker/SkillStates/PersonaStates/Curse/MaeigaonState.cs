using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaeigaonState : MaeihaState {

        public override float spCost { get; } = 16f;

        protected override void ActivateSkill() {
            damageCoefficient = 8f;
            recoilAmplitude = 0f;
            projectilePrefab = Object.Instantiate(Asset.eigaonPrefab);
            spiralMovement = projectilePrefab.AddComponent<SpiralMovement>();
        }
    }
}