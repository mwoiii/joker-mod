using EntityStates;
using RoR2;
using UnityEngine;
//Since we are using effects from Commando's Barrage skill, we will also be using the associated namespace
//You can also use Addressables or LegacyResourcesAPI to load whichever effects you like
using EntityStates.Commando.CommandoWeapon;
using System;

namespace SkillTest.MyEntityStates {
    public class Fire : BaseSkillState {
        public float baseDuration = 0.05f;
        private float duration;

        public GameObject hitEffectPrefab = FireBarrage.hitEffectPrefab;
        public GameObject tracerEffectPrefab = FireBarrage.tracerEffectPrefab;

        protected Ray aimRay;

        //OnEnter() runs once at the start of the skill
        //All we do here is create a BulletAttack and fire it
        public override void OnEnter() {
            base.OnEnter();

            GenericSkill skill = base.skillLocator.secondary;
            if (skill.stock == skill.maxStock) {
                skill.rechargeStopwatch = 0f;
            }
            skill.DeductStock(1);

            this.duration = this.baseDuration / base.attackSpeedStat;
            aimRay = base.GetAimRay();
            base.StartAimMode(aimRay, 2f, false);
            // base.PlayAnimation("Gesture Additive, Right", "FirePistol, Right");
            Util.PlaySound(FireBarrage.fireBarrageSoundString, base.gameObject);
            base.AddRecoil(-0.6f, 0.6f, -0.6f, 0.6f);

            // movement if airborne
            ApplyPhysics();

            if (FireBarrage.effectPrefab) {
                EffectManager.SimpleMuzzleFlash(FireBarrage.effectPrefab, base.gameObject, "MuzzleRight", false);
            }

            if (base.isAuthority) {
                GetBullet().Fire();
            }

        }

        protected virtual void ApplyPhysics() {
            if (!base.characterBody.characterMotor.isGrounded) {

                Vector3 force = aimRay.direction * -1000f;

                // y movement is directly setting velocity instead of using force
                float velocity_y = base.characterBody.characterMotor.velocity.y;
                float shoot_y_velocity = 20f * Math.Abs(aimRay.direction.y);

                // acting as a form of double jump 
                if (base.characterBody.characterMotor.velocity.y <= shoot_y_velocity && force.y >= 0) {
                    velocity_y = shoot_y_velocity;
                } else if (base.characterBody.characterMotor.velocity.y < 0 && force.y < 0) {
                    velocity_y = base.characterBody.characterMotor.velocity.y / 10;
                }

                force.y = 0;

                base.characterBody.characterMotor.velocity.y = velocity_y;
                base.characterBody.characterMotor.ApplyForce(force);
            }
        }

        protected virtual BulletAttack GetBullet() {
            BulletAttack bullet = new BulletAttack {
                owner = base.gameObject,
                weapon = base.gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = base.characterBody.damage * 1.5f,
                force = 3,
                radius = 3f,
                falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                tracerEffectPrefab = this.tracerEffectPrefab,
                muzzleName = "MuzzleRight",
                hitEffectPrefab = this.hitEffectPrefab,
                isCrit = base.RollCrit(),
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 300f
            };
            return bullet;
        }

        //This method runs once at the end
        //Here, we are doing nothing
        public override void OnExit() {
            base.OnExit();
        }

        //FixedUpdate() runs almost every frame of the skill
        //Here, we end the skill once it exceeds its intended duration
        public override void FixedUpdate() {
            base.FixedUpdate();
            if (base.fixedAge >= this.duration && base.isAuthority) {
                this.outer.SetNextStateToMain();
                return;
            }
        }

        //GetMinimumInterruptPriority() returns the InterruptPriority required to interrupt this skill
        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Skill;
        }
    }
}