using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class AgidyneState : PersonaSkillBaseState {

        public override float spCost { get; } = 12f;

        protected virtual GameObject projectilePrefab => Asset.agidynePrefab;

        protected virtual float damage => characterBody.damage * 1f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 position = aimRay.origin + forward * 10f;

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
                rotation = rotation,
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab,
                speedOverride = -1f,
                target = null
            });
        }
    }
}
