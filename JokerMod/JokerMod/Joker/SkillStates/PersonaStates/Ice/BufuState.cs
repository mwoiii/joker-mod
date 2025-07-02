using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class BufuState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.bufuPrefab;

        protected virtual float spawnRadius => 10f;

        protected virtual int projectileQuantity => 12;

        protected virtual float projectileIntervalLower => 0.06f;

        protected virtual float projectileIntervalUpper => 0.1f;

        protected virtual float projectileSpeed => 55f;

        protected virtual float spawnHeight => 7f;

        protected virtual float forwardDirectionMult => 1.15f;

        protected override void ActivateSkill() {
            base.master.StartCoroutine(FireProjectiles());
        }

        private IEnumerator FireProjectiles() {
            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

            Vector3 basePosition = aimRay.origin + Vector3.up * spawnHeight;

            FireProjectileInfo projectileInfo = new FireProjectileInfo {
                damage = characterBody.damage,
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab,
                speedOverride = projectileSpeed,
                target = null
            };

            float prevAngle = (float)Utils.rand.NextDouble() * 360f;
            for (int i = 0; i < projectileQuantity; i++) {

                // there are 270 degrees of freedom
                float angle = (float)Utils.rand.NextDouble() * 270f;

                // no two projectiles to spawn within the same 90 degree sector
                if (angle > (prevAngle - 45f) % 360f) {
                    angle += 90f;
                }

                float x = (float)Utils.rand.NextDouble() * spawnRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
                float z = (float)Utils.rand.NextDouble() * spawnRadius * Mathf.Sin(angle * Mathf.Deg2Rad);

                projectileInfo.position = basePosition + new Vector3(x, 0f, z);
                projectileInfo.rotation = Util.QuaternionSafeLookRotation(Vector3.down + forward * forwardDirectionMult);
                projectileInfo.crit = RollCrit();
                ProjectileManager.instance.FireProjectile(projectileInfo);

                prevAngle = angle % 360f;
                yield return new WaitForSeconds(projectileIntervalLower + (float)Utils.rand.NextDouble() * (projectileIntervalUpper - projectileIntervalLower));
            }
        }
    }
}
