using System;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {
    public class FireBurst : Fire {

        private int stock;

        public override void OnEnter() {
            // Getting actual stock before base class deducts one
            // and deducting rest of the stock
            stock = skillLocator.secondary.stock;
            skillLocator.secondary.stock = 0;
            base.OnEnter();

        }

        protected override void ApplyPhysics() {
            if (!characterBody.characterMotor.isGrounded) {

                Vector3 force = aimRay.direction * (-1000f - 400f * stock);

                float velocity_y = characterBody.characterMotor.velocity.y;
                float shoot_y_velocity = (20f + 2f * stock) * Math.Abs(aimRay.direction.y);

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

        protected override BulletAttack GetBullet() {
            BulletAttack bullet = new BulletAttack {
                owner = gameObject,
                weapon = gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = characterBody.damage * 1.5f * stock,
                force = 5,
                radius = 5f,
                falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                tracerEffectPrefab = tracerEffectPrefab,
                muzzleName = "MuzzleRight",
                hitEffectPrefab = hitEffectPrefab,
                isCrit = RollCrit(),
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            return bullet;
        }
    }
}