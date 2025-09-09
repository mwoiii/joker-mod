using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Modules;
using JokerMod.Modules.PersonaSkills;
using RoR2.Audio;
using UnityEngine.Networking;

namespace JokerMod.Joker.SkillStates.BaseStates {
    public abstract class PersonaSkillBaseState : BaseState {

        protected JokerMaster master;

        public virtual float baseSPCost { get; }

        public virtual SkillTypes.SkillType skillType => SkillTypes.SkillType.Passive;

        protected bool canFire;

        protected float baseDuration = 0.2f;

        protected float duration;

        public PersonaSkillBaseState() { }

        public override void OnEnter() {

            duration = baseDuration / attackSpeedStat;

            master = GetComponent<JokerMaster>();

            if (!(bool)master) {
                Log.Error("Player without JokerMaster attemping to cast a Joker skill! Returning...");
                return;
            }

            if (master.statController.TryCastSkill(baseSPCost)) {
                // rolling separately to allow for specific persona callout
                if (NetworkServer.active) {
                    if (master.voiceController.RollForSoundEvent(JokerAssets.castSkillAttackSoundEvents)) {
                        if (Utils.rand.NextDouble() > 0.25) {
                            // standard callout
                            if (skillType.IsSupportType()) {
                                VoiceController.PlayRandomNetworkedSound(JokerAssets.castSkillSupportSoundEvents, characterBody.gameObject);
                            } else {
                                VoiceController.PlayRandomNetworkedSound(JokerAssets.castSkillAttackSoundEvents, characterBody.gameObject);
                            }
                        } else {
                            // persona callout
                            EntitySoundManager.EmitSoundServer(master.statController.GetPersonaFromLastSkill().calloutSound.akId, characterBody.gameObject);
                        }
                    }
                }
                master.skillUsed = true;
                canFire = true;
            }

            if (canFire && characterBody.hasEffectiveAuthority) {
                ActivateSkill();
            } else {
                baseDuration = 0f;
            }

            base.OnEnter();
        }

        protected abstract void ActivateSkill();

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (fixedAge >= duration && isAuthority) {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Frozen;
        }
    }
}