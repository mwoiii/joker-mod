using System;
using System.Collections;
using System.Collections.Generic;
using EntityStates;
using JokerMod.Joker.Components.Animation;
using RoR2.Skills;
using UnityEngine;

namespace JokerMod.Modules.BaseStates {
    public abstract class BaseAnimatedMeleeAttack : BaseMeleeAttack {

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
            public Action customBehaviour;

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
            /// <param name="customBehaviour">A custom action that will be executed when the event occurs.</param>
            public SubstepAction(float occurrenceTime, float forwardMovement = float.NegativeInfinity, float upwardMovement = float.NegativeInfinity,
                                 float rightMovement = float.NegativeInfinity, float smoothMovementStart = 0f, float smoothMovementEnd = 0f,
                                 bool shouldRepeatMovement = true, bool shouldResetHitbox = false, bool negateBoneY = false, float damageCoefficient = float.NegativeInfinity,
                                 float procCoefficient = float.NegativeInfinity, Action customBehaviour = null) {
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
                this.customBehaviour = customBehaviour;

                this.substepCount = -1;
            }
        }

        protected bool isInputtingMovement => inputBank.rawMoveUp.down || inputBank.rawMoveUp.down || inputBank.rawMoveLeft.down || inputBank.rawMoveRight.down;

        protected bool justJumped;

        protected Vector3 prevMovement;

        protected float prevStart;

        protected float prevEnd;

        protected float prevSubstepStart;

        protected float attackSpdMult;

        protected bool earlyMovementCancel;

        protected List<SubstepAction> substepActions;

        private int currentSubstepCount;

        private BoneDeltaNeutralizer boneDeltaNeutralizer;

        public override void OnEnter() {
            characterBody.onJump += () => justJumped = true;
            currentSubstepCount = -1;
            boneDeltaNeutralizer = modelLocator?.modelTransform?.GetComponent<BoneDeltaNeutralizer>();
            base.OnEnter();
            CalculateNewAttackSpdMult();
        }

        protected virtual void CalculateNewAttackSpdMult() {
            attackSpdMult = baseDuration / duration;
            if (attackSpdMult > 1f) {
                attackSpdMult = 1f + ((attackSpdMult - 1f) * 0.33f);
                duration = (baseDuration / attackSpdMult);
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            bool holdingMoveOnEnd = outer.CanInterruptState(InterruptPriority.Any) && isInputtingMovement;
            earlyMovementCancel = ((justJumped || holdingMoveOnEnd) && isGrounded);
            if (earlyMovementCancel) {
                PlayCrossfade("FullBody, Override", "BufferEmpty", 0.4f);
                if (justJumped) {
                    OverrideNextStep(0);
                    characterBody.StartCoroutine(ClaimSkill1());
                }
                outer.SetNextStateToMain();
                return;
            }

            bool fireEnded = stopwatch >= duration * attackEndPercentTime;
            if (!fireEnded && (bool)characterMotor && isGrounded) {
                characterMotor.velocity.x *= 0.01f;
                characterMotor.velocity.z *= 0.01f;
            }

            justJumped = false;
            UpdateSubstepAction();
        }

        private IEnumerator ClaimSkill1() {
            skillLocator.primary.skillDef.mustKeyPress = true;
            float stopwatch = 0f;
            while (inputBank.skill1.down && stopwatch < 0.3f) {
                stopwatch += GetDeltaTime();
                yield return null;
            }
            skillLocator.primary.skillDef.mustKeyPress = false;
        }

        private void UpdateSubstepAction() {

            if (substepActions == null) {
                return;
            }

            for (int i = substepActions.Count - 1; i >= 0; i--) {
                SubstepAction action = substepActions[i];
                bool shouldBreak = false;
                bool shouldTryMove = false;
                float forwardMovement = 0f;
                float upwardMovement = 0f;
                float rightMovement = 0f;
                float smoothMovementStart = 0f;
                float smoothMovementEnd = 0f;

                if ((action.occurrenceTime / baseDuration) * duration <= stopwatch) {

                    // if it might be the currently executing substep (movement only), get movement data
                    if (action.substepCount != -1 && currentSubstepCount == action.substepCount) {
                        shouldTryMove = true;
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
                        shouldTryMove = true;
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
                        prevSubstepStart = action.occurrenceTime;

                        if (boneDeltaNeutralizer != null) {
                            boneDeltaNeutralizer.negateY = action.negateBoneY;
                        }

                        action.customBehaviour?.Invoke();

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

                if (shouldTryMove) {
                    if (forwardMovement == float.NegativeInfinity && upwardMovement == float.NegativeInfinity && rightMovement == float.NegativeInfinity) {
                        break;
                    }

                    if (forwardMovement == float.NegativeInfinity) {
                        forwardMovement = 0f;
                    }

                    if (upwardMovement == float.NegativeInfinity) {
                        upwardMovement = 0f;
                    }

                    if (rightMovement == float.NegativeInfinity) {
                        rightMovement = 0f;
                    }

                    Vector3 movement = characterDirection.forward * (forwardMovement * GetDeltaTime()) +
                                       Vector3.up * (upwardMovement * GetDeltaTime()) +
                                       Vector3.Cross(Vector3.up, characterDirection.forward).normalized * (rightMovement * GetDeltaTime());

                    Vector3 leftoverMovement = Vector3.zero;
                    float thisPrevStart = prevStart;
                    float thisPrevEnd = prevEnd;

                    if (upwardMovement != 0f) {
                        characterMotor.Motor.ForceUnground();
                    } else {
                        leftoverMovement = prevMovement;
                    }

                    ApplySmoothedMovement(movement, smoothMovementStart, smoothMovementEnd);

                    if (leftoverMovement.y != 0) {
                        characterMotor.velocity.y = GetSmoothedMovement(leftoverMovement, thisPrevStart, thisPrevEnd, prevSubstepStart).y / GetDeltaTime();
                    }

                    // Log.Info($"setting y vel to {previousYMovement / GetDeltaTime()} ({previousYMovement} / {GetDeltaTime()})");
                }

                if (shouldBreak) {
                    break;
                }
            }
        }

        protected void ApplySmoothedMovement(Vector3 movement, float start, float end) {
            if ((bool)characterMotor && (bool)characterDirection) {
                // storing for consistent final y velocity on y movement end (see updatesubstepaction) ((it won't be any clearer though))
                prevMovement = movement;
                prevStart = start;
                prevEnd = end;

                // attack speed mult
                movement *= attackSpdMult;
                start /= attackSpdMult;
                end /= attackSpdMult;

                // movement speed mult
                if (isInputtingMovement && !characterBody.isSprinting) {
                    float walkSpdMult = (characterBody.moveSpeed / characterBody.baseMoveSpeed) * 1.1f;
                    movement.x *= walkSpdMult;
                    movement.z *= walkSpdMult;
                } else if (characterBody.isSprinting) {
                    float runSpdMult = (characterBody.moveSpeed / characterBody.baseMoveSpeed) * (1f + ((characterBody.sprintingSpeedMultiplier - 1f) * 0.33f));
                    movement.x *= runSpdMult;
                    movement.z *= runSpdMult;
                }

                Vector3 smoothedMovement = GetSmoothedMovement(movement, start, end, stopwatch);

                characterMotor.velocity.x = 0f;
                characterMotor.velocity.z = 0f;
                if (smoothedMovement.y != 0) {
                    characterMotor.velocity.y = 0f;
                }

                characterMotor.rootMotion += smoothedMovement;
            }
        }

        private Vector3 GetSmoothedMovement(Vector3 movement, float start, float end, float time) {
            float middleTime = start + (Mathf.Abs(end - start) / 2f);
            Vector3 smoothedMovement;
            if (time < middleTime) {
                smoothedMovement = movement * Mathf.InverseLerp(start, middleTime, time);
            } else {
                smoothedMovement = movement * Mathf.InverseLerp(end, middleTime, time);
            }
            return smoothedMovement;
        }

        protected void OverrideNextStep(int step) {
            SteppedSkillDef.InstanceData instanceData = (SteppedSkillDef.InstanceData)skillLocator.primary.skillInstanceData;
            instanceData.step = step;
            skillLocator.primary.skillInstanceData = instanceData;
        }

        // made specifically for combo 1 finisher
        // if you start moving before it finishes it would lead to severe animation jank
        private IEnumerator WaitBeforeResetYNegation() {
            yield return new WaitForSeconds(0.4f);
            boneDeltaNeutralizer.negateY = false;
        }

        public override void OnExit() {
            base.OnExit();
            characterBody.StartCoroutine(WaitBeforeResetYNegation());
            if (stopwatch < duration) {
                PlayCrossfade("FullBody, Override", "BufferEmpty", 0.4f);
            }
        }
    }
}