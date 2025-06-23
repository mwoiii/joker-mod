using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaeihaState : PersonaSkillProjectileBaseState {

        public override float spCost { get; } = 10f;

        private const float dispersion = 2f;

        protected SpiralMovement spiralMovement;

        protected override void ActivateSkill() {
            damageCoefficient = 3f;
            recoilAmplitude = 0f;
            projectilePrefab = Object.Instantiate(Asset.eihaPrefab);
            spiralMovement = projectilePrefab.AddComponent<SpiralMovement>();
        }
        public override void FireProjectile() {
            for (int i = 0; i < 3; i++) {
                spiralMovement.angle = i * 120f * Mathf.Deg2Rad;
                base.FireProjectile();
            }
        }

        public override Ray ModifyProjectileAimRay(Ray aimRay) {
            aimRay.origin += Vector3.up * 4f;
            return aimRay;
        }
    }
}