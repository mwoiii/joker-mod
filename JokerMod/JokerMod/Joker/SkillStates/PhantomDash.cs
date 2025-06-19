using EntityStates;
using EntityStates.Huntress;
using EntityStates.Merc;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace JokerMod.Joker.SkillStates {
    public class PhantomDash : BaseSkillState {
        private Transform modelTransform;

        public static GameObject blinkPrefab = BlinkState.blinkPrefab;

        private float stopwatch;

        private Vector3 blinkVector = Vector3.zero;

        [SerializeField]
        public float duration = 0.12f;

        [SerializeField]
        public float speedCoefficient = 20f;

        [SerializeField]
        public string beginSoundString = EvisDash.beginSoundString;

        [SerializeField]
        public string endSoundString = EvisDash.endSoundString;

        protected bool exceededDuration => stopwatch >= duration;

        private CharacterModel characterModel;

        private HurtBoxGroup hurtboxGroup;

        public override void OnEnter() {
            base.OnEnter();

            if (NetworkServer.active) {
                characterBody.AddBuff(RoR2Content.Buffs.HiddenInvincibility);
            }

            skillLocator.utility.rechargeStopwatch = 0f;
            skillLocator.utility.DeductStock(1);

            Util.PlaySound(beginSoundString, gameObject);
            modelTransform = GetModelTransform();
            if ((bool)modelTransform) {
                characterModel = modelTransform.GetComponent<CharacterModel>();
                hurtboxGroup = modelTransform.GetComponent<HurtBoxGroup>();
            }
            if ((bool)characterModel) {
                characterModel.invisibilityCount++;
            }
            if ((bool)hurtboxGroup) {
                HurtBoxGroup hurtBoxGroup = hurtboxGroup;
                int hurtBoxesDeactivatorCounter = hurtBoxGroup.hurtBoxesDeactivatorCounter + 1;
                hurtBoxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
            }
            blinkVector = GetBlinkVector();
            CreateBlinkEffect(Util.GetCorePosition(gameObject));
        }

        protected virtual Vector3 GetBlinkVector() {
            return inputBank.aimDirection;
        }

        private void CreateBlinkEffect(Vector3 origin) {
            EffectData effectData = new EffectData();
            effectData.rotation = Util.QuaternionSafeLookRotation(blinkVector);
            effectData.origin = origin;
            EffectManager.SpawnEffect(blinkPrefab, effectData, transmit: false);
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            stopwatch += GetDeltaTime();

            // Applying movement
            if ((bool)characterMotor && (bool)characterDirection) {
                characterMotor.velocity = Vector3.zero;
                characterMotor.rootMotion += blinkVector * (moveSpeedStat * speedCoefficient * GetDeltaTime());
            }

            // Dashing time expired
            if (isAuthority && exceededDuration) {
                outer.SetNextStateToMain();
            }
        }

        public override void OnExit() {
            if (!outer.destroying) {
                Util.PlaySound(endSoundString, gameObject);
                CreateBlinkEffect(Util.GetCorePosition(gameObject));
                modelTransform = GetModelTransform();
                if ((bool)modelTransform) {
                    TemporaryOverlayInstance temporaryOverlayInstance = TemporaryOverlayManager.AddOverlay(modelTransform.gameObject);
                    temporaryOverlayInstance.duration = 0.6f;
                    temporaryOverlayInstance.animateShaderAlpha = true;
                    temporaryOverlayInstance.alphaCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
                    temporaryOverlayInstance.destroyComponentOnEnd = true;
                    temporaryOverlayInstance.originalMaterial = LegacyResourcesAPI.Load<Material>("Materials/matHuntressFlashBright");
                    temporaryOverlayInstance.AddToCharacterModel(modelTransform.GetComponent<CharacterModel>());
                    TemporaryOverlayInstance temporaryOverlayInstance2 = TemporaryOverlayManager.AddOverlay(modelTransform.gameObject);
                    temporaryOverlayInstance2.duration = 0.7f;
                    temporaryOverlayInstance2.animateShaderAlpha = true;
                    temporaryOverlayInstance2.alphaCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);
                    temporaryOverlayInstance2.destroyComponentOnEnd = true;
                    temporaryOverlayInstance2.originalMaterial = LegacyResourcesAPI.Load<Material>("Materials/matHuntressFlashExpanded");
                    temporaryOverlayInstance2.AddToCharacterModel(modelTransform.GetComponent<CharacterModel>());
                }
            }
            if ((bool)characterModel) {
                characterModel.invisibilityCount--;
            }
            if ((bool)hurtboxGroup) {
                HurtBoxGroup hurtBoxGroup = hurtboxGroup;
                int hurtBoxesDeactivatorCounter = hurtBoxGroup.hurtBoxesDeactivatorCounter - 1;
                hurtBoxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
            }
            if (NetworkServer.active) {
                characterBody.RemoveBuff(RoR2Content.Buffs.HiddenInvincibility);
            }
            if ((bool)characterMotor) {
                characterMotor.disableAirControlUntilCollision = false;
            }
            base.OnExit();
        }
    }
}