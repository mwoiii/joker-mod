using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MafreiState : PersonaSkillBaseState {

        public override float spCost { get; } = 10f;

        protected virtual GameObject projectilePrefab => Asset.freiPrefab;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            bool crit = RollCrit();

            FireProjectileInfo projectileInfo = new FireProjectileInfo {
                damage = characterBody.damage,
                crit = crit,
                position = aimRay.origin,
                procChainMask = default(ProcChainMask),
                owner = gameObject,
                projectilePrefab = projectilePrefab
            };

            for (int i = -1; i <= 1; i++) {
                Quaternion spreadRotation = Quaternion.AngleAxis(30f * i, Vector3.up);
                projectileInfo.rotation = Quaternion.LookRotation(spreadRotation * aimRay.direction);
                ProjectileManager.instance.FireProjectile(projectileInfo);
            }
        }
    }
}