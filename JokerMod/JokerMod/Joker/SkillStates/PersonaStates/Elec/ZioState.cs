using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.DamageTypes;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class ZioState : PersonaSkillBaseState {

        public override float baseSPCost { get; } = 4f;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            bool crit = RollCrit();

            BulletAttack bullet = new BulletAttack {
                owner = gameObject,
                weapon = gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = characterBody.damage * 3f,
                force = 0,
                radius = 4f,
                falloffModel = BulletAttack.FalloffModel.None,
                // tracerEffectPrefab = tracerEffectPrefab,
                // muzzleName = "MuzzleRight",
                // hitEffectPrefab = hitEffectPrefab,
                isCrit = crit,
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            bullet.AddModdedDamageType(ElecLightType.damageType);
            bullet.Fire();

            // followup explonion at collision point
            Ray ray = new Ray(aimRay.origin, aimRay.direction);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 500f, LayerIndex.world.mask)) {
                BlastAttack blastAttack = new BlastAttack {
                    attacker = gameObject,
                    baseDamage = characterBody.damage * 1.5f,
                    crit = crit,
                    falloffModel = BlastAttack.FalloffModel.None,
                    inflictor = gameObject,
                    position = hitInfo.point,
                    procChainMask = default(ProcChainMask),
                    procCoefficient = 1f,
                    radius = 8f,
                    teamIndex = characterBody.teamComponent.teamIndex,
                };
                blastAttack.AddModdedDamageType(ElecLightType.damageType);
                blastAttack.Fire();
            }
        }
    }
}