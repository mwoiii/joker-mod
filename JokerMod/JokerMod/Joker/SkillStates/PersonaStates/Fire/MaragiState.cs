using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MaragiState : PersonaSkillBaseState {

        public override float spCost { get; } = 10f;

        protected virtual GameObject projectilePrefab => Asset.agiPrefab;

        protected virtual float damage => characterBody.damage * 3f;

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
                aimRay.origin + forward * 8f,
                aimRay.origin + forward * 6f + right * 10f,
                aimRay.origin + forward * 6f - right * 10f,
            ];


            foreach (Vector3 position in positions) {

                ProjectileManager.instance.FireProjectile(new FireProjectileInfo {
                    damage = damage,
                    crit = crit,
                    position = position,
                    procChainMask = default(ProcChainMask),
                    owner = gameObject,
                    projectilePrefab = projectilePrefab,
                    speedOverride = -1f,
                    target = null
                });
            }
        }
    }
}
