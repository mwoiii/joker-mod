using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MazioState : PersonaSkillBaseState {

        public override float spCost { get; } = 10f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            bool crit = RollCrit();

            BulletAttack bullet = new BulletAttack {
                owner = gameObject,
                weapon = gameObject,
                origin = aimRay.origin,

                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = characterBody.damage * 3f,
                force = 0,
                radius = 4f,
                falloffModel = BulletAttack.FalloffModel.None,
                isCrit = crit,
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            bullet.AddModdedDamageType(ElecLightType.damageType);

            BlastAttack blastAttack = new BlastAttack {
                attacker = gameObject,
                baseDamage = characterBody.damage * 1.5f,
                crit = crit,
                falloffModel = BlastAttack.FalloffModel.None,
                inflictor = gameObject,
                procChainMask = default(ProcChainMask),
                procCoefficient = 1f,
                radius = 8f,
                teamIndex = characterBody.teamComponent.teamIndex,
            };
            blastAttack.AddModdedDamageType(ElecLightType.damageType);

            for (int i = -1; i <= 1; i++) {
                Vector3 aimVector = Quaternion.AngleAxis(25f * i, Vector3.up) * aimRay.direction;
                bullet.aimVector = aimVector;
                bullet.Fire();

                Ray ray = new Ray(aimRay.origin, aimVector);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 500f, LayerIndex.world.mask)) {
                    blastAttack.position = hitInfo.point;
                    blastAttack.Fire();
                }
            }
        }
    }
}