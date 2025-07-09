using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaeihaState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 10f;

        protected virtual GameObject projectilePrefab => Asset.eihaPrefab;

        private const float dispersion = 2f;

        protected override void ActivateSkill() {
            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            aimRay = ModifyAimRay(aimRay);

            bool crit = RollCrit();

            for (int i = 0; i < 3; i++) {
                GameObject projectile = Object.Instantiate(projectilePrefab);
                SpiralMovement spiralMovement = projectile.AddComponent<SpiralMovement>();
                spiralMovement.angle = i * 120f * Mathf.Deg2Rad;
                ProjectileManager.instance.FireProjectile(new FireProjectileInfo {
                    damage = characterBody.damage,
                    crit = crit,
                    position = aimRay.origin,
                    rotation = Quaternion.LookRotation(aimRay.direction),
                    procChainMask = default(ProcChainMask),
                    owner = gameObject,
                    projectilePrefab = projectile
                });
                Destroy(projectile);
            }

        }

        private Ray ModifyAimRay(Ray aimRay) {
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