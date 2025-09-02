using System;
using EntityStates;
//Since we are using effects from Commando's Barrage skill, we will also be using the associated namespace
//You can also use Addressables or LegacyResourcesAPI to load whichever effects you like
using EntityStates.Commando.CommandoWeapon;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
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

            GenericSkill skill = skillLocator.secondary;
            if (skill.stock == skill.maxStock) {
                skill.rechargeStopwatch = 0f;
            }
            skill.DeductStock(1);

            duration = baseDuration / attackSpeedStat;
            aimRay = GetAimRay();
            StartAimMode(aimRay, 2f, false);
            // base.PlayAnimation("Gesture Additive, Right", "FirePistol, Right");
            AddRecoil(-0.6f, 0.6f, -0.6f, 0.6f);

            // movement if airborne
            ApplyPhysics();

            if (FireBarrage.effectPrefab) {
                EffectManager.SimpleMuzzleFlash(FireBarrage.effectPrefab, gameObject, "MuzzleRight", false);
            }

            if (isAuthority) {
                GetBullet().Fire();
                EffectManager.SimpleSoundEffect(JokerAssets.fireSoundEvent.index, gameObject.transform.position, true);
            }

        }

        protected virtual void ApplyPhysics() {
            if (characterBody.hasEffectiveAuthority && !characterBody.characterMotor.isGrounded) {

                Vector3 force = aimRay.direction * -1000f;

                // y movement is directly setting velocity instead of using force
                float velocity_y = characterBody.characterMotor.velocity.y;
                float shoot_y_velocity = 20f * Math.Abs(aimRay.direction.y);

                // acting as a form of double jump 
                if (characterBody.characterMotor.velocity.y <= shoot_y_velocity && force.y >= 0) {
                    velocity_y = shoot_y_velocity;
                } else if (characterBody.characterMotor.velocity.y < 0 && force.y < 0) {
                    velocity_y = characterBody.characterMotor.velocity.y / 10;
                }

                force.y = 0;

                characterBody.characterMotor.velocity.y = velocity_y;
                characterBody.characterMotor.ApplyForce(force);
            }
        }

        protected virtual BulletAttack GetBullet() {
            BulletAttack bullet = new BulletAttack {
                owner = characterBody.gameObject,
                weapon = characterBody.gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = characterBody.damage * JokerStaticValues.fireDamageCoefficient,
                force = 3,
                radius = 3f,
                falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                tracerEffectPrefab = tracerEffectPrefab,
                muzzleName = "MuzzleRight",
                hitEffectPrefab = hitEffectPrefab,
                isCrit = RollCrit(),
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                damageType = DamageTypeCombo.GenericSecondary,
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
            if (fixedAge >= duration && isAuthority) {
                outer.SetNextStateToMain();
                return;
            }
        }

        //GetMinimumInterruptPriority() returns the InterruptPriority required to interrupt this skill
        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Skill;
        }
    }
}