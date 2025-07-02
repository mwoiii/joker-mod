using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaragionState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 16f;

        protected virtual GameObject projectilePrefab => Asset.agilaoPrefab;

        protected virtual float damage => characterBody.damage * 1.25f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.up, forward);
            right.Normalize();

            Vector3[] positions = [
                aimRay.origin + forward * 10f,
                aimRay.origin + forward * 8f + right * 12f,
                aimRay.origin + forward * 8f - right * 12f,
            ];

            foreach (Vector3 position in positions) {
                FireProjectileInfo fireProjectileInfo = new FireProjectileInfo {
                    damage = damage,
                    crit = crit,
                    position = position,
                    procChainMask = default(ProcChainMask),
                    owner = gameObject,
                    projectilePrefab = projectilePrefab,
                    speedOverride = -1f,
                    target = null
                };

                base.master.StartCoroutine(FireProjectiles(fireProjectileInfo));
            }


        }

        private IEnumerator FireProjectiles(FireProjectileInfo fireProjectileInfo) {
            for (int i = 0; i < 4; i++) {
                ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
