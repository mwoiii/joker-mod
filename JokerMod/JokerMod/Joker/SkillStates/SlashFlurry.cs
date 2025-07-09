using System.Collections;
using System.Collections.Generic;
using EntityStates;
using JokerMod.Joker.Components.Animation;
using JokerMod.Modules.BaseStates;
using RoR2;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Joker.SkillStates {

    public class SlashFlurry : BaseMeleeAttack {

        public class SubstepAction {
            public float occurrenceTime;
            public float forwardMovement;
            public float upwardMovement;
            public float rightMovement;
            public float smoothMovementStart;
            public float smoothMovementEnd;
            public bool shouldRepeatMovement;
            public bool shouldResetHitbox;
            public bool negateBoneY;
            public float damageCoefficient;
            public float procCoefficient;
            public float nonRepeatYVelocity;

            public int substepCount;

            /// <summary>
            /// Creates a data container for a substep action.
            /// </summary>
            /// <param name="occurrenceTime">Time in seconds when this event should occur during its animation at base speed (attack speed scaling is automatic).</param>
            /// <param name="forwardMovement">The rate at which the player will be moved forward during the substep. Repeats if shouldRepeatMovement is true (default).</param>
            /// <param name="upwardMovement">The rate at which the player will be moved upward during the substep. Repeats if shouldRepeatMovement is true (default).</param>
            /// <param name="rightMovement">The rate at which the player will be moved to the right during the substep. Repeats if shouldRepeatMovement is true (default).</param>
            /// <param name="smoothMovementStart">The starting boundary of smooth movement. Shape is a linear up and down slope, with start and end being 0, and middle being the peak.</param>
            /// <param name="smoothMovementEnd">The end boundary of smooth movement. Shape is a linear up and down slope, with start and end being 0, and middle being the peak.</param>
            /// <param name="shouldRepeatMovement">Whether or not the specified movements should repeat until the next substep.</param>
            /// <param name="shouldResetHitbox">Whether or not the attack hitbox should forget all healthcomponents, allowing it to hit the same enemies again.</param>
            /// <param name="negateBoneY">Whether or not Y movement on the root bone should be negated until the next substep.</param>
            /// <param name="damageCoefficient">Damage that the attack should deal from this point onward, unless it is changed by a future substep.</param>
            /// <param name="procCoefficient">Proc coefficient that the attack should have from this point onward, unless it is changed by a future substep.</param>
            public SubstepAction(float occurrenceTime, float forwardMovement, float upwardMovement = 0f, float rightMovement = 0f, float smoothMovementStart = 0f,
                                 float smoothMovementEnd = 0f, bool shouldRepeatMovement = true, bool shouldResetHitbox = false, bool negateBoneY = false,
                                 float damageCoefficient = float.NegativeInfinity, float procCoefficient = float.NegativeInfinity) {
                this.occurrenceTime = occurrenceTime;
                this.forwardMovement = forwardMovement;
                this.upwardMovement = upwardMovement;
                this.rightMovement = rightMovement;
                this.smoothMovementStart = smoothMovementStart;
                this.shouldRepeatMovement = shouldRepeatMovement;
                this.smoothMovementEnd = smoothMovementEnd;
                this.shouldResetHitbox = shouldResetHitbox;
                this.negateBoneY = negateBoneY;
                this.damageCoefficient = damageCoefficient;
                this.procCoefficient = procCoefficient;

                this.substepCount = -1;
            }
        }

        private int currentSubstepCount;

        private List<SubstepAction> substepActions;

        private bool justJumped;

        private BoneDeltaNeutralizer boneDeltaNeutralizer;

        private float yMovement;

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
            boneDeltaNeutralizer = modelLocator?.modelTransform?.GetComponent<BoneDeltaNeutralizer>();

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
                    OverrideStep(0);
                    break;
                case 7:
                    baseDuration = 1.23f;
                    attackStartPercentTime = 0.24f;
                    attackEndPercentTime = 0.41f;
                    earlyExitPercentTime = 0.80f;
                    InitCombo7SubstepActions();
                    OverrideStep(0);
                    break;
                case 8:
                    baseDuration = 1.13f;
                    attackStartPercentTime = 0.23f;
                    attackEndPercentTime = 0.53f;
                    earlyExitPercentTime = 0.7f;
                    InitCombo8SubstepActions();
                    OverrideStep(0);
                    break;
                case 10:
                    baseDuration = 1.4f;
                    attackStartPercentTime = 0.16f;
                    attackEndPercentTime = 0.52f;
                    earlyExitPercentTime = 0.69f;
                    InitCombo10SubstepActions();
                    OverrideStep(0);
                    break;
                case 11:
                    baseDuration = 1.6f;
                    attackStartPercentTime = 0.25f;
                    attackEndPercentTime = 0.65f;
                    earlyExitPercentTime = 0.77f;
                    InitCombo11SubstepActions();
                    OverrideStep(0);
                    break;
            }

            characterBody.onJump += SetJustJumped;

            base.OnEnter();
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            bool holdingMoveOnEnd = outer.CanInterruptState(InterruptPriority.Any) && (inputBank.rawMoveUp.down || inputBank.rawMoveUp.down || inputBank.rawMoveLeft.down || inputBank.rawMoveRight.down);
            if (justJumped || holdingMoveOnEnd) {
                PlayCrossfade("FullBody, Override", "BufferEmpty", 0.4f);
                if (justJumped) {
                    characterBody.StartCoroutine(HoldOnJumpInterrupt());
                }
                outer.SetNextStateToMain();
                return;
            }

            // finishers
            if (inputBank.activateEquipment.justPressed && swingIndex < 5) {
                OverrideStep(swingIndex + 6);
            }

            bool fireEnded = stopwatch >= duration * attackEndPercentTime;
            if (!fireEnded && (bool)characterMotor) {
                characterMotor.velocity.x *= 0.1f;
                characterMotor.velocity.z *= 0.1f;
            }

            UpdateSubstepAction();
            justJumped = false;
        }

        private IEnumerator HoldOnJumpInterrupt() {
            skillLocator.primary.skillDef.mustKeyPress = true;
            while (inputBank.skill1.down) {
                yield return null;
            }
            skillLocator.primary.skillDef.mustKeyPress = false;
        }

        private void SetJustJumped() {
            justJumped = true;
        }

        private void UpdateSubstepAction() {

            for (int i = substepActions.Count - 1; i >= 0; i--) {
                SubstepAction action = substepActions[i];
                bool shouldBreak = false;
                bool shouldMove = false;
                float forwardMovement = 0f;
                float upwardMovement = 0f;
                float rightMovement = 0f;
                float smoothMovementStart = 0f;
                float smoothMovementEnd = 0f;

                if ((action.occurrenceTime / baseDuration) * duration <= stopwatch) {

                    // if it might be the currently executing substep (movement only), get movement data
                    if (action.substepCount != -1 && currentSubstepCount == action.substepCount) {
                        shouldMove = true;
                        forwardMovement = action.forwardMovement;
                        upwardMovement = action.upwardMovement;
                        rightMovement = action.rightMovement;
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
                        upwardMovement = action.upwardMovement;
                        rightMovement = action.rightMovement;
                        smoothMovementStart = action.smoothMovementStart;
                        smoothMovementEnd = action.smoothMovementEnd;

                        if (boneDeltaNeutralizer != null) {
                            if (boneDeltaNeutralizer.negateY != action.negateBoneY) {
                                Log.Info($"flipping from {action.negateBoneY} to {!action.negateBoneY}");
                            }
                            boneDeltaNeutralizer.negateY = action.negateBoneY;
                        }

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
                    Vector3 movement = characterDirection.forward * (forwardMovement * GetDeltaTime()) +
                                       Vector3.up * (upwardMovement * GetDeltaTime()) +
                                       Vector3.Cross(Vector3.up, characterDirection.forward).normalized * (rightMovement * GetDeltaTime());

                    float previousYMovement = 0f;

                    if (upwardMovement != 0f) {
                        characterMotor.Motor.ForceUnground();
                    } else {
                        previousYMovement = yMovement;
                    }

                    ApplySmoothedMovement(movement, smoothMovementStart, smoothMovementEnd);
                    characterMotor.velocity.y = previousYMovement / GetDeltaTime();

                    // Log.Info($"setting y vel to {previousYMovement / GetDeltaTime()} ({previousYMovement} / {GetDeltaTime()})");
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
                    forwardMovement: 15f,
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
                    forwardMovement: 11f,
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
                    forwardMovement: 21f,
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
                    forwardMovement: 15f,
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
                    forwardMovement: 15f,
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
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true,
                    damageCoefficient: 2.5f
                ),
                new SubstepAction(
                    occurrenceTime: 0.57f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.43f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    damageCoefficient: 0.8f
                )
            };
        }

        // ^ main combo ^
        // v finishers v

        private void InitCombo7SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.49f,
                    forwardMovement: 0f,
                    upwardMovement: 0f,
                    shouldRepeatMovement: false,
                    negateBoneY: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.29f,
                    forwardMovement: 8f,
                    upwardMovement: 150f,
                    smoothMovementStart: 0.09f,
                    smoothMovementEnd: 0.52f,
                    negateBoneY: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 0f,
                    negateBoneY: true
                )
            };
        }

        private void InitCombo8SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.36f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.26f,
                    forwardMovement: 230f,
                    smoothMovementStart: 0.16f,
                    smoothMovementEnd: 0.56f,
                    damageCoefficient: 2.5f
                )
            };
        }

        private void InitCombo10SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.63f,
                    forwardMovement: 0f,
                    rightMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.5f,
                    forwardMovement: 184f,
                    rightMovement: 276f,
                    smoothMovementStart: 0.5f,
                    smoothMovementEnd: 0.89f,
                    shouldResetHitbox: true,
                    damageCoefficient: 3f
                ),
                new SubstepAction(
                    occurrenceTime: 0.3f,
                    forwardMovement: 0f,
                    rightMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.2f,
                    forwardMovement: 70f,
                    rightMovement: -100f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.5f,
                    damageCoefficient: 2.5f
                )
            };
        }

        private void InitCombo11SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.76f,
                    forwardMovement: 0f,
                    upwardMovement: 0f,
                    negateBoneY: true,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.66f,
                    forwardMovement: 40f,
                    upwardMovement: 50f,
                    smoothMovementStart: 0.56f,
                    smoothMovementEnd: 0.81f,
                    damageCoefficient: 4f,
                    negateBoneY: true,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.5f,
                    forwardMovement: 0f,
                    upwardMovement: 0f,
                    shouldRepeatMovement: false,
                    negateBoneY: true,
                    shouldResetHitbox: true
                ),
                new SubstepAction(
                    occurrenceTime: 0.36f,
                    forwardMovement: 40f,
                    upwardMovement: 25f,
                    smoothMovementStart: 0.36f,
                    smoothMovementEnd: 0.55f,
                    negateBoneY: true,
                    damageCoefficient: 3f
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
                    smoothedMovement = movement * Mathf.InverseLerp(start, middleTime, stopwatch);
                } else {
                    smoothedMovement = movement * Mathf.InverseLerp(end, middleTime, stopwatch);
                }

                characterMotor.velocity = Vector3.zero;
                yMovement = smoothedMovement.y;
                characterMotor.rootMotion += smoothedMovement;
            }
        }

        protected override void PlayAttackAnimation() {
            int comboNum = 1 + swingIndex;
            if (comboNum <= 6) {
                PlayCrossfade("FullBody, Override", $"AttackCombo{comboNum}", playbackRateParam, duration, 0.1f * duration);
            } else {
                PlayCrossfade("FullBody, Override", $"AttackCombo{comboNum % 6}Finisher", playbackRateParam, duration, 0.1f * duration);
            }
        }

        protected override void PlaySwingEffect() {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority() {
            base.OnHitEnemyAuthority();
        }

        private void OverrideStep(int step) {
            SteppedSkillDef.InstanceData instanceData = (SteppedSkillDef.InstanceData)skillLocator.primary.skillInstanceData;
            instanceData.step = step;
            skillLocator.primary.skillInstanceData = instanceData;
        }

        public override void OnExit() {
            base.OnExit();
            characterBody.StartCoroutine(WaitBeforeResetYNegation());
            if (stopwatch < duration) {
                PlayCrossfade("FullBody, Override", "BufferEmpty", 0.4f);
            }
        }

        // made specifically for combo 1 finisher
        // if you start moving before it finishes it would lead to severe animation jank
        private IEnumerator WaitBeforeResetYNegation() {
            yield return new WaitForSeconds(0.4f);
            boneDeltaNeutralizer.negateY = false;
        }
    }
}