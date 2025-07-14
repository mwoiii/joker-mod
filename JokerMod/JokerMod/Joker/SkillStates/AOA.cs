using System.Collections.Generic;
using System.Linq;
using EntityStates;
using EntityStates.Merc;
using JokerMod.Joker.Components;
using RoR2;
using RoR2.Audio;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

namespace JokerMod.Joker.SkillStates {
    public class AOA : BaseState {
        private Transform modelTransform;

        public static GameObject blinkPrefab = Evis.blinkPrefab;

        public static float duration = 1.4f;

        public virtual float damageCoefficient => JokerStaticValues.aoaDamageCoefficient;

        public static float damageFrequency = 10f;

        public static float procCoefficient = 0.8f;

        public static AkEventIdArg beginSound = JokerAssets.thrashStartSoundEvent.akId;

        public static AkEventIdArg stopSound = JokerAssets.thrashStopSoundEvent.akId;

        public static NetworkSoundEventIndex endSound = JokerAssets.thrashFinisherSoundEvent.index;

        public static float maxRadius = 24f;

        public static GameObject hitEffectPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Dagger/DaggerImpact.prefab").WaitForCompletion();

        public static string slashSoundString = Evis.slashSoundString;

        public static string impactSoundString = Evis.impactSoundString;

        public static string dashSoundString = Evis.dashSoundString;

        public static float slashPitch = Evis.slashPitch;

        public static float smallHopVelocity = Evis.smallHopVelocity;

        public static float lingeringInvincibilityDuration = Evis.lingeringInvincibilityDuration;

        private Animator animator;

        private CharacterModel characterModel;

        private float stopwatch;

        private float attackStopwatch;

        private bool crit;

        private static float minimumDuration = 0.5f;

        private CameraTargetParams.AimRequest aimRequest;

        protected AOAController attackHandler;

        protected virtual void StartHitHandling() {
            attackHandler.StartExecution();
        }

        public override void OnEnter() {
            base.OnEnter();

            attackHandler = GetComponent<AOAController>();

            // When AOA triggers, reset skill cooldown
            // and start listening to global deaths
            StartHitHandling();

            CreateBlinkEffect(Util.GetCorePosition(gameObject));
            EntitySoundManager.EmitSoundServer(beginSound, gameObject);
            crit = Util.CheckRoll(critStat, characterBody.master);
            modelTransform = GetModelTransform();
            if ((bool)modelTransform) {
                animator = modelTransform.GetComponent<Animator>();
                characterModel = modelTransform.GetComponent<CharacterModel>();
            }
            if ((bool)characterModel) {
                characterModel.invisibilityCount++;
            }
            if ((bool)cameraTargetParams) {
                aimRequest = cameraTargetParams.RequestAimType(CameraTargetParams.AimType.Aura);
            }
            if (NetworkServer.active) {
                characterBody.AddBuff(RoR2Content.Buffs.HiddenInvincibility);
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            float deltaTime = GetDeltaTime();
            stopwatch += deltaTime;
            attackStopwatch += deltaTime;
            float num = 1f / damageFrequency / attackSpeedStat;
            if (attackStopwatch >= num) {
                attackStopwatch -= num;
                IEnumerable<HurtBox> hurtBoxes = SearchForTargets();
                if (!hurtBoxes.Any(hurtBox => (bool)hurtBox) && isAuthority && stopwatch > minimumDuration) {
                    outer.SetNextStateToMain();
                }
                foreach (var hurtBox in hurtBoxes) {
                    if ((bool)hurtBox) {
                        Util.PlayAttackSpeedSound(slashSoundString, gameObject, slashPitch);
                        Util.PlaySound(dashSoundString, gameObject);
                        Util.PlaySound(impactSoundString, gameObject);
                        HurtBoxGroup hurtBoxGroup = hurtBox.hurtBoxGroup;
                        HurtBox hurtBox2 = hurtBoxGroup.hurtBoxes[Random.Range(0, hurtBoxGroup.hurtBoxes.Length - 1)];
                        if ((bool)hurtBox2) {
                            Vector3 position = hurtBox2.transform.position;
                            Vector2 normalized = Random.insideUnitCircle.normalized;
                            EffectManager.SimpleImpactEffect(normal: new Vector3(normalized.x, 0f, normalized.y), effectPrefab: hitEffectPrefab, hitPos: position, transmit: false);
                            Transform transform = hurtBox.hurtBoxGroup.transform;
                            TemporaryOverlayInstance temporaryOverlayInstance = TemporaryOverlayManager.AddOverlay(transform.gameObject);
                            temporaryOverlayInstance.duration = num;
                            temporaryOverlayInstance.animateShaderAlpha = true;
                            temporaryOverlayInstance.alphaCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
                            temporaryOverlayInstance.destroyComponentOnEnd = true;
                            temporaryOverlayInstance.originalMaterial = LegacyResourcesAPI.Load<Material>("Materials/matMercEvisTarget");
                            temporaryOverlayInstance.AddToCharacterModel(transform.GetComponent<CharacterModel>());
                            if (NetworkServer.active) {
                                DamageInfo damageInfo = new DamageInfo();
                                damageInfo.damage = damageCoefficient * damageStat;
                                damageInfo.attacker = gameObject;
                                damageInfo.procCoefficient = procCoefficient;
                                damageInfo.position = hurtBox2.transform.position;
                                damageInfo.crit = crit;
                                damageInfo.damageType |= (DamageTypeCombo)DamageType.BonusToLowHealth;
                                damageInfo.damageType.damageSource = DamageSource.Special;
                                hurtBox2.healthComponent.TakeDamage(damageInfo);
                                GlobalEventManager.instance.OnHitEnemy(damageInfo, hurtBox2.healthComponent.gameObject);
                                GlobalEventManager.instance.OnHitAll(damageInfo, hurtBox2.healthComponent.gameObject);
                            }
                        }
                    }
                }
            }
            if ((bool)characterMotor) {
                characterMotor.velocity = Vector3.zero;
            }
            if (stopwatch >= duration && isAuthority) {
                outer.SetNextStateToMain();
            }
        }

        // I should change this,,,
        // but I will forget I wrote this
        private IEnumerable<HurtBox> SearchForTargets() {
            BullseyeSearch bullseyeSearch = new BullseyeSearch();
            bullseyeSearch.searchOrigin = transform.position;
            bullseyeSearch.searchDirection = Random.onUnitSphere;
            bullseyeSearch.maxDistanceFilter = maxRadius;
            bullseyeSearch.teamMaskFilter = TeamMask.GetUnprotectedTeams(GetTeam());
            bullseyeSearch.sortMode = BullseyeSearch.SortMode.Distance;
            bullseyeSearch.RefreshCandidates();
            bullseyeSearch.FilterOutGameObject(gameObject);
            return bullseyeSearch.GetResults();
        }

        private void CreateBlinkEffect(Vector3 origin) {
            EffectData effectData = new EffectData();
            effectData.rotation = Util.QuaternionSafeLookRotation(Vector3.up);
            effectData.origin = origin;
            EffectManager.SpawnEffect(blinkPrefab, effectData, transmit: false);
        }

        public override void OnExit() {
            EntitySoundManager.EmitSoundServer(stopSound, gameObject);
            EffectManager.SimpleSoundEffect(endSound, gameObject.transform.position, true);

            CreateBlinkEffect(Util.GetCorePosition(gameObject));
            modelTransform = GetModelTransform();
            if ((bool)modelTransform) {
                TemporaryOverlayInstance temporaryOverlayInstance = TemporaryOverlayManager.AddOverlay(modelTransform.gameObject);
                temporaryOverlayInstance.duration = 0.6f;
                temporaryOverlayInstance.animateShaderAlpha = true;
                temporaryOverlayInstance.alphaCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
                temporaryOverlayInstance.destroyComponentOnEnd = true;
                temporaryOverlayInstance.originalMaterial = LegacyResourcesAPI.Load<Material>("Materials/matMercEvisTarget");
                temporaryOverlayInstance.AddToCharacterModel(modelTransform.GetComponent<CharacterModel>());
                TemporaryOverlayInstance temporaryOverlayInstance2 = TemporaryOverlayManager.AddOverlay(modelTransform.gameObject);
                temporaryOverlayInstance2.duration = 0.7f;
                temporaryOverlayInstance2.animateShaderAlpha = true;
                temporaryOverlayInstance2.alphaCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
                temporaryOverlayInstance2.destroyComponentOnEnd = true;
                temporaryOverlayInstance2.originalMaterial = LegacyResourcesAPI.Load<Material>("Materials/matHuntressFlashExpanded");
                temporaryOverlayInstance2.AddToCharacterModel(modelTransform.GetComponent<CharacterModel>());
            }
            if ((bool)characterModel) {
                characterModel.invisibilityCount--;
            }
            aimRequest?.Dispose();
            if (NetworkServer.active) {
                characterBody.RemoveBuff(RoR2Content.Buffs.HiddenInvincibility);
                characterBody.AddTimedBuff(RoR2Content.Buffs.HiddenInvincibility, lingeringInvincibilityDuration);
            }

            // Stop listening to global deaths
            attackHandler.StopExecution();
            SmallHop(characterMotor, smallHopVelocity);
            base.OnExit();
        }


    }
}
