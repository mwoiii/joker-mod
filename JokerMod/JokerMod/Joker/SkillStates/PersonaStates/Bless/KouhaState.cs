using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class KouhaState : PersonaSkillBaseState {

        public override float spCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.kouhaPrefab;

        protected virtual int startPitch => -10;

        protected virtual int incPitch => 20;

        protected virtual int maxPitch => 10;

        protected virtual int startYaw => -45;

        protected virtual int incYaw => 30;

        protected virtual int maxYaw => 45;

        protected virtual bool ignoreY => false;

        protected virtual float fixedDistance => 20f;

        protected override void ActivateSkill() {
            base.master.StartCoroutine(FireProjectiles());
        }

        private IEnumerator FireProjectiles() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            FireProjectileInfo projectileInfo = new FireProjectileInfo {
                damage = characterBody.damage,
                position = aimRay.origin,
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab,
            };

            Vector3 direction = aimRay.direction;
            if (ignoreY) {
                direction.y = 0f;
            }

            Vector3 right = Vector3.Cross(Vector3.up, direction);

            for (int i = startPitch; i <= maxPitch; i += incPitch) {
                // up / down
                Quaternion spreadPitch = Quaternion.AngleAxis(-i, right);
                Vector3 baseDirection = spreadPitch * direction;

                for (int j = startYaw; j <= maxYaw; j += incYaw) {
                    // left / right
                    Quaternion spreadYaw = Quaternion.AngleAxis(j, Vector3.up);
                    Vector3 bulletDirection = spreadYaw * baseDirection;


                    for (int k = 0; k < 3; k++) {
                        // front / back & spread
                        bulletDirection = Util.ApplySpread(bulletDirection, 0f, 10f, 1.5f, 1f);
                        projectileInfo.rotation = Quaternion.LookRotation(bulletDirection);
                        projectileInfo.speedOverride = 18f + (float)Utils.rand.NextDouble() * 5f + fixedDistance * k;

                        projectileInfo.crit = RollCrit();
                        ProjectileManager.instance.FireProjectile(projectileInfo);
                    }
                    yield return new WaitForFixedUpdate();
                }
            }
        }
    }
}