using System.Collections.Generic;
using JokerMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {

    public class SlashFlurry : BaseMeleeAttack {

        private class SubstepAction {
            public float occurrenceTime;
            public float forwardMovement;
            public float smoothMovementStart;
            public float smoothMovementEnd;
            public bool shouldRepeatMovement;
            public bool shouldResetHitbox;
            public float damageCoefficient;
            public float procCoefficient;

            public int substepCount;

            public SubstepAction(float occurrenceTime, float forwardMovement, float smoothMovementStart = 0f, float smoothMovementEnd = 0f, bool shouldRepeatMovement = true,
                                 bool shouldResetHitbox = false, float damageCoefficient = float.NegativeInfinity, float procCoefficient = float.NegativeInfinity) {
                this.occurrenceTime = occurrenceTime;
                this.forwardMovement = forwardMovement;
                this.smoothMovementStart = smoothMovementStart;
                this.shouldRepeatMovement = shouldRepeatMovement;
                this.smoothMovementEnd = smoothMovementEnd;
                this.shouldResetHitbox = shouldResetHitbox;
                this.damageCoefficient = damageCoefficient;
                this.procCoefficient = procCoefficient;

                this.substepCount = -1;
            }
        }

        private int currentSubstepCount;

        private List<SubstepAction> substepActions;

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

            currentSubstepCount = -1;

            switch (swingIndex + 1) {
                case 1:
                    baseDuration = 0.93f;
                    attackStartPercentTime = 0.17f; // 0.1581
                    attackEndPercentTime = 0.43f; // 0.4
                    earlyExitPercentTime = 0.3f; // 0.3441
                    InitCombo1SubstepActions();
                    break;
                case 2:
                    baseDuration = 0.93f;
                    attackStartPercentTime = 0.46f; // 0.4278
                    attackEndPercentTime = 0.79f; // 0.7347
                    earlyExitPercentTime = 0.57f; // 0.5301
                    InitCombo2SubstepActions();
                    break;
                case 3:
                    baseDuration = 1f;
                    attackStartPercentTime = 0.26f; // 0.26
                    attackEndPercentTime = 0.54f; // 0.54
                    earlyExitPercentTime = 0.36f; // 0.36
                    InitCombo3SubstepActions();
                    break;
                case 4:
                    baseDuration = 1.46f;
                    attackStartPercentTime = 0.20f; // 0.292
                    attackEndPercentTime = 0.5f; // 0.73
                    earlyExitPercentTime = 0.41f; // 0.5986
                    InitCombo4SubstepActions();
                    break;
                case 5:
                    baseDuration = 1.2f;
                    attackStartPercentTime = 0.22f; // 0.264
                    attackEndPercentTime = 0.61f; // 0.732
                    earlyExitPercentTime = 0.5f; // 0.6
                    InitCombo5SubstepActions();
                    break;
                case 6:
                    baseDuration = 1.6f;
                    attackStartPercentTime = 0.16f; // 0.256
                    attackEndPercentTime = 0.63f; // 1.008
                    earlyExitPercentTime = 0.79f; // 1.264
                    InitCombo6SubstepActions();
                    break;
            }

            base.OnEnter();
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            bool fireEnded = stopwatch >= duration * attackEndPercentTime;
            if (!fireEnded) {
                if ((bool)characterMotor) {
                    characterMotor.velocity *= 0.1f;
                }
                UpdateSubstepAction();
            }
        }

        private void UpdateSubstepAction() {
            // theoretically could function erroneously if two substep actions are too close to each other
            // so don't do that

            for (int i = substepActions.Count - 1; i >= 0; i--) {
                SubstepAction action = substepActions[i];
                bool shouldBreak = false;
                bool shouldMove = false;
                float forwardMovement = 0f;
                float smoothMovementStart = 0f;
                float smoothMovementEnd = 0f;
                if ((action.occurrenceTime / baseDuration) * duration <= stopwatch) {

                    // if it might be the currently executing substep (movement only), get movement data
                    if (action.substepCount != -1 && currentSubstepCount == action.substepCount) {
                        shouldMove = true;
                        forwardMovement = action.forwardMovement;
                        smoothMovementStart = action.smoothMovementStart;
                        smoothMovementEnd = action.smoothMovementEnd;
                    }

                    // otherwise if it's definitely an old movement substep, remove
                    else if (action.substepCount != -1 && currentSubstepCount != action.substepCount) {
                        substepActions.RemoveAt(i);
                    }

                    // if it's a new substep that should be executed now, do so and update the stepcount and break
                    if (action.substepCount == -1) {
                        shouldBreak = true;
                        shouldMove = true;
                        currentSubstepCount++;

                        if (action.damageCoefficient != float.NegativeInfinity) {
                            attack.damage = damageStat * action.damageCoefficient;
                        }
                        if (action.procCoefficient != float.NegativeInfinity) {
                            attack.procCoefficient = action.procCoefficient;
                        }

                        forwardMovement = action.forwardMovement;
                        smoothMovementStart = action.smoothMovementStart;
                        smoothMovementEnd = action.smoothMovementEnd;

                        if (action.shouldResetHitbox) {
                            attack.ResetIgnoredHealthComponents();
                        }

                        if (action.shouldRepeatMovement) {
                            action.substepCount = currentSubstepCount;
                        } else {
                            substepActions.RemoveAt(i);
                        }
                    }
                }

                if (shouldMove) {
                    ApplySmoothedMovement(characterDirection.forward * (forwardMovement * GetDeltaTime()), smoothMovementStart, smoothMovementEnd);
                }

                if (shouldBreak) {
                    break;
                }
            }
        }

        private void InitCombo1SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.25f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0f,
                    smoothMovementEnd: 0.25f
                )
            };
        }

        private void InitCombo2SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.54f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0f,
                    smoothMovementEnd: 0.54f,
                    damageCoefficient: 1.2f
                )
            };
        }

        private void InitCombo3SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.46f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.2f,
                    forwardMovement: 17f,
                    smoothMovementStart: 0.2f,
                    smoothMovementEnd: 0.40f,
                    damageCoefficient: 1.4f
                )
            };
        }

        private void InitCombo4SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.42f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.27f,
                    forwardMovement: 7f,
                    smoothMovementStart: 0.27f,
                    smoothMovementEnd: 0.42f,
                    damageCoefficient: 1.6f
                )
            };
        }

        private void InitCombo5SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.68f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.43f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.68f,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.72f,
                    damageCoefficient: 0.9f
                )
            };
        }

        private void InitCombo6SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.8f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.7f,
                    forwardMovement: 7f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true,
                    damageCoefficient: 2.5f
                ),
                new SubstepAction(
                    occurrenceTime: 0.57f,
                    forwardMovement: 7f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.43f,
                    forwardMovement: 7f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 7f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    damageCoefficient: 0.8f
                )
            };
        }

        private void ApplySmoothedMovement(Vector3 movement, float start, float end) {
            if ((bool)characterMotor && (bool)characterDirection) {
                movement *= baseDuration / duration;
                start *= duration / baseDuration;
                end *= duration / baseDuration;

                float middleTime = start + (Mathf.Abs(end - start) / 2f);
                Vector3 smoothedMovement;

                if (stopwatch < middleTime) {
                    smoothedMovement = movement * Mathf.InverseLerp(0f, middleTime, stopwatch);
                } else {
                    smoothedMovement = movement * Mathf.InverseLerp(baseDuration, middleTime, stopwatch);
                }

                characterMotor.velocity = Vector3.zero;
                characterMotor.rootMotion += smoothedMovement;
            }
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