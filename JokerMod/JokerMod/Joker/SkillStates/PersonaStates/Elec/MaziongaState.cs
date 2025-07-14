using System.Collections;
using JokerMod.Joker.SkillStates.BaseStates;
using JokerMod.Modules.DamageTypes;
using JokerMod.Modules.PersonaSkills;
using R2API;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class MaziongaState : PersonaSkillBaseState {

        public override SkillTypes.SkillType skillType => SkillTypes.SkillType.Elec;

        public override float baseSPCost { get; } = 16f;

        private bool crit;

        private BulletAttack bullet;

        private BlastAttack blastAttack;

        private Ray aimRay;

        protected override void ActivateSkill() {

            aimRay = GetAimRay();
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
                procCoefficient = 0.9f,
                damage = characterBody.damage * 1.25f,
                force = 0,
                radius = 5f,
                falloffModel = BulletAttack.FalloffModel.None,
                isCrit = crit,
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            bullet.AddModdedDamageType(ElecMediumType.damageType);

            blastAttack = new BlastAttack {
                attacker = gameObject,
                baseDamage = characterBody.damage * 0.625f,
                crit = crit,
                falloffModel = BlastAttack.FalloffModel.None,
                inflictor = gameObject,
                procChainMask = default(ProcChainMask),
                procCoefficient = 0.9f,
                radius = 9f,
                teamIndex = characterBody.teamComponent.teamIndex,
            };
            blastAttack.AddModdedDamageType(ElecMediumType.damageType);

            base.master.StartCoroutine(FireBullets());
        }

        private IEnumerator FireBullets() {
            int timesFired = 0;
            while (timesFired < 4) {

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
                timesFired++;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}