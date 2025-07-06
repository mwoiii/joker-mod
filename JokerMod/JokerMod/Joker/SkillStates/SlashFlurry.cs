﻿using JokerMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {

    public class SlashFlurry : BaseMeleeAttack {
        public override void OnEnter() {
            hitboxGroupName = "KnifeGroup";

            damageType = DamageTypeCombo.GenericPrimary;
            damageCoefficient = JokerStaticValues.slashFlurryDamageCoefficient;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = Vector3.zero;
            baseDuration = 1f;

            //0-1 multiplier of baseduration, used to time when the hitbox is out (usually based on the run time of the animation)
            //for example, if attackStartPercentTime is 0.5, the attack will start hitting halfway through the ability. if baseduration is 3 seconds, the attack will start happening at 1.5 seconds
            attackStartPercentTime = 0.2f;
            attackEndPercentTime = 0.7f;

            //this is the point at which the attack can be interrupted by itself, continuing a combo
            earlyExitPercentTime = 0.6f;

            hitStopDuration = 0.012f;
            attackRecoil = 0.5f;
            hitHopVelocity = 4f;

            swingSoundString = "HenrySwordSwing";
            hitSoundString = "";
            muzzleString = swingIndex % 2 == 0 ? "SwingLeft" : "SwingRight";
            playbackRateParam = "Slash.playbackRate";
            swingEffectPrefab = JokerAssets.swordSwingEffect;
            hitEffectPrefab = JokerAssets.swordHitImpactEffect;

            impactSound = JokerAssets.swordHitSoundEvent.index;

            base.OnEnter();
        }

        protected override void PlayAttackAnimation() {
            PlayCrossfade("FullBody, Override", "AttackCombo" + (1 + swingIndex), playbackRateParam, duration, 0.1f * duration);
        }

        protected override void PlaySwingEffect() {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority() {
            base.OnHitEnemyAuthority();
        }

        public override void OnExit() {
            base.OnExit();
        }
    }
}