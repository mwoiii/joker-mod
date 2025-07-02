using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class GaruState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.garuPrefab;

        protected virtual float maxRange => 200f;

        protected virtual float damage => 0f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 position;
            if (Physics.Raycast(aimRay, out RaycastHit hitInfo, maxRange, (int)LayerIndex.world.mask | (int)LayerIndex.entityPrecise.mask)) {
                position = hitInfo.point;
            } else {
                Vector3 castPoint = base.transform.position + aimRay.direction * maxRange;
                position = castPoint;
            }

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
