using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class BufuState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Ice;

        public override float baseSPCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.bufuPrefab;

        protected virtual float spawnRadius => 5f;

        protected virtual int projectileQuantity => 12;

        protected virtual float projectileIntervalLower => 0.06f;

        protected virtual float projectileIntervalUpper => 0.1f;

        protected virtual float projectileSpeed => 55f;

        protected virtual float spawnDistance => 0f;

        protected override void ActivateSkill() {
            base.master.StartCoroutine(FireProjectiles());
        }

        private IEnumerator FireProjectiles() {
            Ray aimRay = GetAimRay();

            StartAimMode(aimRay, 2f, false);

            Vector3 direction = aimRay.direction;

            ModifyDirection(ref direction);

            Vector3 relativeRight = Vector3.Cross(Vector3.up, direction).normalized;
            if (relativeRight == Vector3.zero) {
                relativeRight = Vector3.right;
            }

            Vector3 relativeUp = Vector3.Cross(relativeRight, direction).normalized;

            Vector3 basePosition = aimRay.origin - direction * spawnDistance;

            FireProjectileInfo projectileInfo = new FireProjectileInfo {
                damage = characterBody.damage,
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab,
                speedOverride = projectileSpeed,
                rotation = Util.QuaternionSafeLookRotation(direction),
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

                projectileInfo.position = basePosition + relativeRight * x + relativeUp * z;

                projectileInfo.crit = RollCrit();
                ProjectileManager.instance.FireProjectile(projectileInfo);

                prevAngle = angle % 360f;
                yield return new WaitForSeconds(projectileIntervalLower + (float)Utils.rand.NextDouble() * (projectileIntervalUpper - projectileIntervalLower));
            }
        }

        protected virtual void ModifyDirection(ref Vector3 direction) {
        }
    }
}
