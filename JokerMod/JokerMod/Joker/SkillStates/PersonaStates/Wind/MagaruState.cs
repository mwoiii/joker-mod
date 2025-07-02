using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class MagaruState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 10f;

        protected virtual GameObject projectilePrefab => Asset.garuPrefab;

        protected virtual float damage => 0f;

        protected override void ActivateSkill() {

            float offset = projectilePrefab.transform.GetChild(0).localScale.x + 4f;

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.up, forward);
            right.Normalize();

            Vector3[] positions = [
                aimRay.origin + forward * 0.01f,
                aimRay.origin + forward * offset,
                aimRay.origin - forward * offset,
                aimRay.origin + right * offset,
                aimRay.origin - right * offset
            ];

            foreach (Vector3 position in positions) {
                Quaternion rotation = Quaternion.identity;
                Vector3 vector = position - aimRay.origin;
                vector.y = 0f;
                if (vector != Vector3.zero) {
                    rotation = Util.QuaternionSafeLookRotation(vector, Vector3.up);
                }

                ProjectileManager.instance.FireProjectile(new FireProjectileInfo {
                    damage = damage,
                    crit = crit,
                    position = position,
                    procChainMask = default(ProcChainMask),
                    owner = gameObject,
                    projectilePrefab = projectilePrefab,
                    rotation = rotation,
                    speedOverride = -1f,
                    target = null
                });
            }
        }
    }
}
