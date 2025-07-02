using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class AgiState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 4f;

        protected virtual GameObject projectilePrefab => Asset.agiPrefab;

        protected virtual float damage => characterBody.damage * 3f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            bool crit = RollCrit();

            Vector3 forward = aimRay.direction;
            forward.y = 0;
            forward.Normalize();

            Vector3 position = aimRay.origin + forward * 8f;

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
