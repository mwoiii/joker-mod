using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class AgilaoState : PersonaSkillBaseState {

        public override float spCost { get; } = 8f;

        protected virtual GameObject projectilePrefab => Asset.agilaoPrefab;

        protected virtual float damage => characterBody.damage * 1.25f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 position = aimRay.origin + forward * 10f;

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

        private IEnumerator FireProjectiles(FireProjectileInfo fireProjectileInfo) {
            for (int i = 0; i < 4; i++) {
                ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
