using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.DamageTypes;
using JokerMod.Modules.PersonaSkills;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class ZiodyneState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Elec;

        public override float baseSPCost { get; } = 12f;

        private bool crit;

        private BulletAttack bullet;

        private BlastAttack blastAttack;

        bool didImpact;

        protected override void ActivateSkill() {

            Ray aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);

            crit = RollCrit();

            bullet = new BulletAttack {
                owner = gameObject,
                weapon = gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 0.8f,
                damage = characterBody.damage * 1f,
                force = 0,
                radius = 6f,
                falloffModel = BulletAttack.FalloffModel.None,
                isCrit = crit,
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            bullet.AddModdedDamageType(ElecHeavyType.damageType);

            Ray ray = new Ray(aimRay.origin, aimRay.direction);

            blastAttack = new BlastAttack {
                attacker = gameObject,
                baseDamage = characterBody.damage * 0.5f,
                crit = crit,
                falloffModel = BlastAttack.FalloffModel.None,
                inflictor = gameObject,
                procChainMask = default(ProcChainMask),
                procCoefficient = 0.8f,
                radius = 10f,
                teamIndex = characterBody.teamComponent.teamIndex,
            };
            blastAttack.AddModdedDamageType(ElecHeavyType.damageType);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 500f, LayerIndex.world.mask)) {
                didImpact = true;
                blastAttack.position = hitInfo.point;
            }
            base.master.StartCoroutine(FireBullets());
        }

        private IEnumerator FireBullets() {
            int timesFired = 0;
            while (timesFired < 8) {
                bullet.Fire();
                if (didImpact) {
                    blastAttack.Fire();
                }
                timesFired++;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}