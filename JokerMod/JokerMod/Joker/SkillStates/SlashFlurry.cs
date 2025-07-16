using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Joker.Components.SkillHelpers;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using JokerMod.Modules.BaseStates;
using JokerMod.Modules.DamageTypes;
using JokerMod.Modules.PersonaSkills;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JokerMod.Joker.SkillStates {

    public class SlashFlurry : BaseAnimatedMeleeAttack {

        private JokerStatController statController;

        private VoiceController voiceController;

        private bool bufferFinisher;

        private static int slashEventInstanceCount;

        private int _prevHealthComponentCount;

        private int prevHealthComponentCount {
            get {
                return _prevHealthComponentCount;
            }
            set {
                _prevHealthComponentCount = Mathf.Max(0, value);
            }
        }

        public override void OnEnter() {

            statController = characterBody?.master?.GetComponent<JokerStatController>();
            if (statController != null) {
                voiceController = statController.voiceController;
                statController.isUsingPrimary = true;
            }

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
            //swingEffectPrefab = JokerAssets.swordSwingEffect;
            hitEffectPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Dagger/DaggerImpact.prefab").WaitForCompletion();
            impactSound = JokerAssets.primarySlashSoundEvents[0].index;

            // Log.Info($"swingIndex: {swingIndex}");
            if (!isGrounded && swingIndex == 0) {
                swingIndex = 11;
                OverrideNextStep(12);
            }

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
                    OverrideNextStep(0);
                    break;

                case 7:
                    baseDuration = 1.23f;
                    attackStartPercentTime = 0.24f;
                    attackEndPercentTime = 0.41f;
                    earlyExitPercentTime = 0.80f;
                    InitCombo7SubstepActions();
                    OverrideNextStep(0);
                    break;
                case 8:
                    baseDuration = 1.13f;
                    attackStartPercentTime = 0.23f;
                    attackEndPercentTime = 0.53f;
                    earlyExitPercentTime = 0.7f;
                    InitCombo8SubstepActions();
                    OverrideNextStep(0);
                    break;
                case 9:
                    baseDuration = 1.13f;
                    attackStartPercentTime = 0f;
                    attackEndPercentTime = 0f;
                    earlyExitPercentTime = 0.6f;
                    InitCombo9SubstepActions();
                    OverrideNextStep(0);
                    break;
                case 10:
                    baseDuration = 1.4f;
                    attackStartPercentTime = 0.16f;
                    attackEndPercentTime = 0.52f;
                    earlyExitPercentTime = 0.69f;
                    InitCombo10SubstepActions();
                    OverrideNextStep(0);
                    break;
                case 11:
                    baseDuration = 1.6f;
                    attackStartPercentTime = 0.25f;
                    attackEndPercentTime = 0.65f;
                    earlyExitPercentTime = 0.77f;
                    InitCombo11SubstepActions();
                    OverrideNextStep(0);
                    break;

                case 12:
                case 14:
                    baseDuration = 0.66f;
                    attackStartPercentTime = 0.18f;
                    attackEndPercentTime = 0.5f;
                    earlyExitPercentTime = 0.5f;
                    InitCombo12and14SubstepActions();
                    break;
                case 13:
                    baseDuration = 0.73f;
                    attackStartPercentTime = 0.23f;
                    attackEndPercentTime = 0.5f;
                    earlyExitPercentTime = 0.5f;
                    InitCombo13SubstepActions();
                    break;
                case 15:
                    baseDuration = 1.13f;
                    attackStartPercentTime = 0.29f;
                    attackEndPercentTime = 0.59f;
                    earlyExitPercentTime = 0.74f;
                    InitCombo15SubstepActions();
                    break;
            }

            base.OnEnter();
        }

        public override void FixedUpdate() {
            attack.impactSound = ((NetworkSoundEventDef)Utils.RandomChoice(JokerAssets.primarySlashSoundEvents)).index;

            base.FixedUpdate();

            // audio balancing
            int countDif = attack.ignoredHealthComponentList.Count - prevHealthComponentCount;
            if (countDif > 0) {
                slashEventInstanceCount += countDif;
                characterBody.StartCoroutine(SubtractSlashEvents(countDif));
                AkSoundEngine.SetRTPCValue("SlashEventInstanceCount", slashEventInstanceCount);
            }
            prevHealthComponentCount = attack.ignoredHealthComponentList.Count;

            // finishers
            if (!earlyMovementCancel) {
                if (inputBank.activateEquipment.justPressed && swingIndex < 5 && bufferFinisher == false) {
                    bufferFinisher = true;
                } else if (swingIndex > 11 && isGrounded) {
                    PlayCrossfade("FullBody, Override", "BufferEmpty", 0.4f);
                    OverrideNextStep(0);
                    outer.SetNextStateToMain();
                }
            }
            if (outer.CanInterruptState(InterruptPriority.Any) && bufferFinisher) {
                outer.SetNextStateToMain();
            }
        }

        private IEnumerator SubtractSlashEvents(int count) {
            yield return new WaitForSeconds(0.52f);
            slashEventInstanceCount -= count;
            AkSoundEngine.SetRTPCValue("SlashEventInstanceCount", slashEventInstanceCount);
        }

        public static void RejectEquipmentExecution(ILContext il) {
            var isJokerAttackingDelegate = new Func<EquipmentSlot, bool>((EquipmentSlot equipmentSlot) => {
                JokerStatController statController = equipmentSlot?.characterBody?.master?.GetComponent<JokerStatController>();
                if (statController != null) {
                    return statController.isUsingPrimary || statController.master.primaryResetTimerActive;
                }
                return false;
            });

            ILCursor c = new ILCursor(il);
            //EquipmentIndex arg = this.equipmentIndex;
            if (c.TryGotoNext(x => x.MatchLdarg(0)) &&
                c.TryGotoNext(x => x.MatchCallOrCallvirt<EquipmentSlot>("get_equipmentIndex")) &&
                c.TryGotoNext(x => x.MatchCall(typeof(RoR2.EquipmentCatalog).GetMethod(
                    "GetEquipmentDef",
                    BindingFlags.Public | BindingFlags.Static,
                    null,
                    new[] { typeof(RoR2.EquipmentIndex) },
                    null
                ))) &&
                c.TryGotoNext(MoveType.After, x => x.MatchStloc(0))) {
                ILLabel resumeLabel = c.DefineLabel();
                c.Emit(OpCodes.Ldarg_0);
                c.EmitDelegate(isJokerAttackingDelegate);
                c.Emit(OpCodes.Brfalse, resumeLabel);
                c.Emit(OpCodes.Ret);
                c.MarkLabel(resumeLabel);
            } else {
                Log.Error("RejectEquipmentExecution ILHook failed. Joker finisher attacks will activate equipment.");
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
                    smoothMovementEnd: 0.25f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[0].akId,
                    customBehaviour: PlayRandomWeakVoice
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
                    occurrenceTime: 0.43f,
                    forwardMovement: 11f,
                    smoothMovementStart: 0f,
                    smoothMovementEnd: 0.54f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[1].akId,
                    customBehaviour: PlayRandomWeakVoice
                ),
                new SubstepAction(
                    occurrenceTime: 0f,
                    forwardMovement: 11f,
                    smoothMovementStart: 0f,
                    smoothMovementEnd: 0.54f,
                    damageCoefficient: 1.4f
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
                    damageCoefficient: 1.6f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[2].akId,
                    customBehaviour: PlayRandomMediumChargeVoice
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
                    damageCoefficient: 1.8f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[3].akId,
                    customBehaviour: PlayRandomMediumVoice
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
                    occurrenceTime: 0.4f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.72f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId,
                    customBehaviour: PlayRandomWeakVoice
                ),

                new SubstepAction(
                    occurrenceTime: 0.26f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.72f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[5].akId
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.72f,
                    damageCoefficient: 1f
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
                    damageCoefficient: 2.5f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[5].akId,
                    customBehaviour: PlayRandomStrongOrAltVoice
                ),
                new SubstepAction(
                    occurrenceTime: 0.57f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId
                ),
                new SubstepAction(
                    occurrenceTime: 0.43f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    shouldResetHitbox: true,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId
                ),
                new SubstepAction(
                    occurrenceTime: 0.29f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 9f,
                    smoothMovementStart: 0.1f,
                    smoothMovementEnd: 0.8f,
                    damageCoefficient: 1f
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
                    negateBoneY: true,
                    soundEffect: JokerAssets.primarySwingSoundEvents[4].akId,
                    customBehaviour: PlayRandomMediumChargeVoice
                ),
                new SubstepAction(
                    occurrenceTime: 0.1f,
                    forwardMovement: 0f,
                    negateBoneY: true,
                    damageCoefficient: 2.5f
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
                    forwardMovement: 140f,
                    smoothMovementStart: 0.16f,
                    smoothMovementEnd: 0.56f,
                    damageCoefficient: 2.5f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId,
                    customBehaviour: PlayRandomMediumVoice
                )
            };
        }

        private void InitCombo9SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.36f,
                    forwardMovement: 0f,
                    shouldRepeatMovement: false,
                    customBehaviour: Combo9CustomBehaviour
                ),
                new SubstepAction(
                    occurrenceTime: 0f,
                    forwardMovement: 12f,
                    smoothMovementStart: 0f,
                    smoothMovementEnd: 0.36f
                )
            };
        }

        private void Combo9CustomBehaviour() {
            JokerStatController statController = characterBody?.master?.GetComponent<JokerStatController>();

            BlastAttack blastAttack = new BlastAttack {
                attacker = gameObject,
                position = characterBody.transform.position + characterDirection.forward * 14f,
                baseDamage = characterBody.damage * 2f,
                crit = RollCrit(),
                falloffModel = BlastAttack.FalloffModel.None,
                inflictor = gameObject,
                procChainMask = default(ProcChainMask),
                procCoefficient = 1f,
                radius = 12f,
                teamIndex = characterBody.teamComponent.teamIndex,
            };

            HealingPulsePercentage healingPulse = null;

            if (statController != null) {
                switch (statController.primaryPersona.skillType) {
                    case SkillTypes.SkillType.Phys:
                        break;

                    case SkillTypes.SkillType.Gun:
                        break;

                    case SkillTypes.SkillType.Fire:
                        blastAttack.AddModdedDamageType(FireLightWeakType.damageType);
                        break;

                    case SkillTypes.SkillType.Ice:
                        blastAttack.AddModdedDamageType(IceLightType.damageType);
                        break;


                    case SkillTypes.SkillType.Elec:
                        blastAttack.AddModdedDamageType(ElecLightWeakType.damageType);
                        break;


                    case SkillTypes.SkillType.Wind:
                        blastAttack.AddModdedDamageType(IgnoreMassType.damageType);
                        blastAttack.baseForce = 800f;
                        break;

                    case SkillTypes.SkillType.Psy:
                        blastAttack.AddModdedDamageType(PsyLightWeakType.damageType);
                        break;

                    case SkillTypes.SkillType.Nuke:
                        blastAttack.AddModdedDamageType(NukeLightWeakType.damageType);
                        break;

                    case SkillTypes.SkillType.Bless:
                        blastAttack.AddModdedDamageType(BlessLightWeakType.damageType);
                        break;

                    case SkillTypes.SkillType.Curse:
                        blastAttack.AddModdedDamageType(CurseLightWeakType.damageType);
                        break;

                    case SkillTypes.SkillType.Almighty:
                        break;

                    case SkillTypes.SkillType.HealLight:
                        blastAttack = null;
                        healingPulse = new HealingPulsePercentage();
                        healingPulse.healFlat = 22.5f + 1.25f * characterBody.level;
                        healingPulse.origin = characterBody.corePosition;
                        healingPulse.radius = 15f;
                        healingPulse.effectPrefab = DiaState.seekerVFX;
                        healingPulse.fxScale = 1f;
                        healingPulse.teamIndex = characterBody.teamComponent.teamIndex;
                        healingPulse.overShield = 0f;
                        healingPulse.Fire();
                        break;

                    case SkillTypes.SkillType.HealMedium:
                        blastAttack = null;
                        healingPulse = new HealingPulsePercentage();
                        healingPulse.healFlat = 50f + 2.5f * characterBody.level;
                        healingPulse.origin = characterBody.corePosition;
                        healingPulse.radius = 15f;
                        healingPulse.effectPrefab = DiaState.seekerVFX;
                        healingPulse.fxScale = 1f;
                        healingPulse.teamIndex = characterBody.teamComponent.teamIndex;
                        healingPulse.overShield = 0f;
                        healingPulse.Fire();
                        break;

                    case SkillTypes.SkillType.HealHeavy:
                        blastAttack = null;
                        healingPulse = new HealingPulsePercentage();
                        healingPulse.healFlat = 72.5f + 3.75f * characterBody.level;
                        healingPulse.origin = characterBody.corePosition;
                        healingPulse.radius = 15f;
                        healingPulse.effectPrefab = DiaState.seekerVFX;
                        healingPulse.fxScale = 1f;
                        healingPulse.teamIndex = characterBody.teamComponent.teamIndex;
                        healingPulse.overShield = 0f;
                        healingPulse.Fire();
                        break;

                    case SkillTypes.SkillType.HealCleanse:
                        break;

                    case SkillTypes.SkillType.BuffAtk:
                        break;

                    case SkillTypes.SkillType.BuffDef:
                        break;

                    case SkillTypes.SkillType.BuffSpd:
                        break;

                    case SkillTypes.SkillType.BuffAll:
                        break;

                    case SkillTypes.SkillType.DebuffAtk:
                        break;

                    case SkillTypes.SkillType.DebuffDef:
                        break;

                    case SkillTypes.SkillType.DebuffSpd:
                        break;

                    case SkillTypes.SkillType.DebuffAll:
                        break;

                    case SkillTypes.SkillType.Sleep:
                        break;

                    case SkillTypes.SkillType.Forget:
                        break;

                    case SkillTypes.SkillType.Charm:
                        break;

                    case SkillTypes.SkillType.Passive:
                        break;

                    default:
                        break;
                }

                int roll = Utils.rand.Next(2);
                if (roll == 0) {
                    PlayRandomStrongVoice();
                } else {
                    if (statController.primaryPersona.skillType.IsSupportType()) {
                        voiceController.TryPlayRandomNetworkedSound(JokerAssets.castSkillSupportSoundEvents, characterBody.gameObject);
                    } else {
                        voiceController.TryPlayRandomNetworkedSound(JokerAssets.castSkillAttackSoundEvents, characterBody.gameObject);
                    }
                }
            }

            blastAttack?.Fire();
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
                    occurrenceTime: 0.53f,
                    forwardMovement: 120f,
                    rightMovement: 168f,
                    smoothMovementStart: 0.5f,
                    smoothMovementEnd: 0.89f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[6].akId,
                    customBehaviour: PlayRandomStrongAltVoice
                ),
                new SubstepAction(
                    occurrenceTime: 0.5f,
                    forwardMovement: 120f,
                    rightMovement: 168f,
                    smoothMovementStart: 0.5f,
                    smoothMovementEnd: 0.89f,
                    shouldResetHitbox: true,
                    damageCoefficient: 3.5f
                ),
                new SubstepAction(
                    occurrenceTime: 0.4f,
                    forwardMovement: 0f,
                    rightMovement: 0f,
                    shouldRepeatMovement: false
                ),
                new SubstepAction(
                    occurrenceTime: 0.2f,
                    forwardMovement: 40f,
                    rightMovement: -56f,
                    smoothMovementStart: 0.2f,
                    smoothMovementEnd: 0.4f,
                    damageCoefficient: 2.5f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[0].akId
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
                    shouldResetHitbox: true,
                    soundEffect: JokerAssets.primarySwingSoundEvents[5].akId
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
                    occurrenceTime: 0.4f,
                    forwardMovement: 40f,
                    upwardMovement: 25f,
                    smoothMovementStart: 0.36f,
                    smoothMovementEnd: 0.55f,
                    negateBoneY: true,
                    soundEffect: JokerAssets.primarySwingSoundEvents[0].akId,
                    customBehaviour: PlayRandomStrongOrAltVoice
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

        // ^ finishers ^
        // v airborne v

        private void InitCombo12and14SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.16f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[2].akId,
                    customBehaviour: PlayRandomWeakVoice
                )
            };
        }

        private void InitCombo13SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.16f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[3].akId,
                    customBehaviour: PlayRandomWeakVoice
                )
            };
        }

        private void InitCombo15SubstepActions() {
            substepActions = new List<SubstepAction> {
                new SubstepAction(
                    occurrenceTime: 0.4f,
                    soundEffect: JokerAssets.primarySwingSoundEvents[4].akId,
                    customBehaviour: PlayRandomMediumVoice
                ),
                new SubstepAction(
                    occurrenceTime: 0f,
                    damageCoefficient: 2f
                )
            };
        }
        private void PlayRandomWeakVoice() {
            voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceWeakSoundEvents, characterBody.gameObject);
        }

        private void PlayRandomMediumChargeVoice() {
            voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceMediumChargeSoundEvents, characterBody.gameObject);
        }

        private void PlayRandomMediumVoice() {
            voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceMediumSoundEvents, characterBody.gameObject);
        }

        private void PlayRandomStrongVoice() {
            voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceStrongSoundEvents, characterBody.gameObject);
        }
        private void PlayRandomStrongAltVoice() {
            voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceStrongAltSoundEvents, characterBody.gameObject);
        }

        private void PlayRandomStrongOrAltVoice() {
            if (Utils.rand.Next(2) == 0) {
                voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceStrongSoundEvents, characterBody.gameObject);
            } else {
                voiceController?.TryPlayRandomUniqueNetworkedSound(JokerAssets.primaryVoiceStrongAltSoundEvents, characterBody.gameObject);
            }

        }

        protected override void PlayAttackAnimation() {
            int comboNum = 1 + swingIndex;
            switch (comboNum) {
                case <= 6:
                    PlayCrossfade("FullBody, Override", $"AttackCombo{comboNum}", playbackRateParam, duration, 0.1f * duration);
                    break;
                case <= 11:
                    PlayCrossfade("FullBody, Override", $"AttackCombo{comboNum - 6}Finisher", playbackRateParam, duration, 0.1f * duration);
                    break;
                case <= 15:
                    PlayCrossfade("FullBody, Override", $"AttackAirborneCombo{comboNum - 11}", playbackRateParam, duration, 0.1f * duration);
                    break;
            }
        }

        protected override void PlaySwingEffect() {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority() {
            base.OnHitEnemyAuthority();
        }

        public override void OnExit() {
            base.OnExit();
            if (statController != null) {
                statController.isUsingPrimary = false;
            }

            if (bufferFinisher) {
                OverrideNextStep(swingIndex + 6);
                skillLocator.primary.ExecuteIfReady();
            }
        }
    }
}