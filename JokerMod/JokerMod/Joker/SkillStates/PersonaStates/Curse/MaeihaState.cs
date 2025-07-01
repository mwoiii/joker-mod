using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
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
            Object.Destroy(projectilePrefab);
        }

        public override Ray ModifyProjectileAimRay(Ray aimRay) {
            Vector3 newOrigin = aimRay.origin + Vector3.up * 4f;

            // center should hit original target still
            if (Physics.Raycast(aimRay, out RaycastHit hitInfo, 500f, LayerIndex.world.mask)) {
                aimRay.direction = (hitInfo.point - newOrigin).normalized;
            }
            aimRay.origin = newOrigin;
            return aimRay;
        }
    }
}