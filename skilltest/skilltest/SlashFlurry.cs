using EntityStates;
using RoR2;
using UnityEngine.Networking;
using UnityEngine;
using RoR2.Skills;
using EntityStates.Merc.Weapon;
using RoR2.AddressableAssets;
using UnityEngine.AddressableAssets;

namespace SkillTest.MyEntityStates {
    public class SlashFlurry : BasicMeleeAttack, SteppedSkillDef.IStepSetter {
        
        public int step;
        /*

        public static float recoilAmplitude = GroundLight2.recoilAmplitude;

        public static float baseDurationBeforeInterruptable = GroundLight2.baseDurationBeforeInterruptable;

        public float bloom = 5f;

        public static float comboFinisherBaseDuration = GroundLight2.comboFinisherBaseDuration;

        public static GameObject comboFinisherSwingEffectPrefab = GroundLight2.comboFinisherSwingEffectPrefab;

        public static float comboFinisherhitPauseDuration = GroundLight2.comboFinisherhitPauseDuration;

        public static float comboFinisherDamageCoefficient = GroundLight2.comboFinisherDamageCoefficient;

        public static float comboFinisherBloom = GroundLight2.comboFinisherBloom;

        public static float comboFinisherBaseDurationBeforeInterruptable = GroundLight2.comboFinisherBaseDurationBeforeInterruptable;

        public static string slash1Sound = GroundLight2.slash1Sound;

        public static string slash3Sound = GroundLight2.slash3Sound;

        public new GameObject swingEffectPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Junk/Characters/Merc/Skills/ImpactMercSwing.prefab").WaitForCompletion();

        private string animationStateName;

        private float durationBeforeInterruptable;

        private bool isComboFinisher => step == 2;

        public override bool allowExitFire {
            get {
                if ((bool)base.characterBody) {
                    return !base.characterBody.isSprinting;
                }
                return false;
            }
        }

        */
        void SteppedSkillDef.IStepSetter.SetStep(int i) {
            step = i;
        }
        /*

        public override void OnEnter() {
            if (isComboFinisher) {
                swingEffectPrefab = comboFinisherSwingEffectPrefab;
                hitPauseDuration = comboFinisherhitPauseDuration;
                damageCoefficient = comboFinisherDamageCoefficient;
                bloom = comboFinisherBloom;
                hitBoxGroupName = "SwordLarge";
                baseDuration = comboFinisherBaseDuration;
            }
            base.OnEnter();
            base.characterDirection.forward = GetAimRay().direction;
            durationBeforeInterruptable = (isComboFinisher ? (comboFinisherBaseDurationBeforeInterruptable / attackSpeedStat) : (baseDurationBeforeInterruptable / attackSpeedStat));
        }

        public override void OnExit() {
            base.OnExit();
        }

        public override void AuthorityModifyOverlapAttack(OverlapAttack overlapAttack) {
            base.AuthorityModifyOverlapAttack(overlapAttack);
            if (isComboFinisher) {
                overlapAttack.damageType = DamageType.ApplyMercExpose;
            }
            overlapAttack.damageType.damageSource = DamageSource.Primary;
        }

        public override void PlayAnimation() {
            animationStateName = "";
            string soundString = null;
            switch (step) {
                case 0:
                    animationStateName = "GroundLight1";
                    soundString = slash1Sound;
                    break;
                case 1:
                    animationStateName = "GroundLight2";
                    soundString = slash1Sound;
                    break;
                case 2:
                    animationStateName = "GroundLight3";
                    soundString = slash3Sound;
                    break;
            }
            bool @bool = animator.GetBool("isMoving");
            bool bool2 = animator.GetBool("isGrounded");
            if (!@bool && bool2) {
                PlayCrossfade("FullBody, Override", animationStateName, "GroundLight.playbackRate", duration, 0.05f);
            } else {
                PlayCrossfade("Gesture, Additive", animationStateName, "GroundLight.playbackRate", duration, 0.05f);
                PlayCrossfade("Gesture, Override", animationStateName, "GroundLight.playbackRate", duration, 0.05f);
            }
            Util.PlaySound(soundString, base.gameObject);
        }

        public override void OnMeleeHitAuthority() {
            base.OnMeleeHitAuthority();
            base.characterBody.AddSpreadBloom(bloom);
        }

        public override void BeginMeleeAttackEffect() {
            swingEffectMuzzleString = animationStateName;
            AddRecoil(-0.1f * recoilAmplitude, 0.1f * recoilAmplitude, -1f * recoilAmplitude, 1f * recoilAmplitude);
            base.BeginMeleeAttackEffect();
        }

        public override void OnSerialize(NetworkWriter writer) {
            base.OnSerialize(writer);
            writer.Write((byte)step);
        }

        public override void OnDeserialize(NetworkReader reader) {
            base.OnDeserialize(reader);
            step = reader.ReadByte();
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            if (!(base.fixedAge < durationBeforeInterruptable)) {
                return InterruptPriority.Skill;
            }
            return InterruptPriority.PrioritySkill;
        }
        */
    }
}