using EntityStates;
using RoR2;
using UnityEngine;
using EntityStates.Commando.CommandoWeapon;
using System;

namespace SkillTest.MyEntityStates {
    public class FireBurst : Fire {

        private int stock;

        public override void OnEnter() {
            // Getting actual stock before base class deducts one
            // and deducting rest of the stock
            stock = base.skillLocator.secondary.stock;
            base.skillLocator.secondary.stock = 0;
            base.OnEnter();

        }

        protected override void ApplyPhysics() {
            if (!base.characterBody.characterMotor.isGrounded) {

                Vector3 force = aimRay.direction * (-1000f - 400f * stock);

                float velocity_y = base.characterBody.characterMotor.velocity.y;
                float shoot_y_velocity = (20f + 2f * stock) * Math.Abs(aimRay.direction.y);

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

        protected override BulletAttack GetBullet() {
            BulletAttack bullet = new BulletAttack {
                owner = base.gameObject,
                weapon = base.gameObject,
                origin = aimRay.origin,
                aimVector = aimRay.direction,
                minSpread = 0f,
                maxSpread = 0f,
                bulletCount = 1U,
                procCoefficient = 1f,
                damage = base.characterBody.damage * 2f * stock,
                force = 5,
                radius = 5f,
                falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                tracerEffectPrefab = this.tracerEffectPrefab,
                muzzleName = "MuzzleRight",
                hitEffectPrefab = this.hitEffectPrefab,
                isCrit = base.RollCrit(),
                HitEffectNormal = false,
                stopperMask = LayerIndex.world.mask,
                smartCollision = true,
                maxDistance = 500f
            };
            return bullet;
        }
    }
}