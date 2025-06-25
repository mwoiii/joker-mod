using EntityStates;
using JokerMod.Joker.Components;

namespace JokerMod.Joker.SkillStates.BaseStates {
    public abstract class PersonaSkillBaseState : BaseState {

        protected JokerMaster master;

        public virtual float spCost { get; }

        protected bool canFire;

        protected float baseDuration = 0.2f;

        protected float duration;

        public override void OnEnter() {

            duration = baseDuration / attackSpeedStat;

            master = GetComponent<JokerMaster>();

            if (!(bool)master) {
                Log.Error("Player without JokerMaster attemping to cast a Joker skill! Returning...");
                return;
            }

            if (master.spController.currentSP >= spCost) {
                master.skillUsed = true;
                master.spController.currentSP -= spCost;
                canFire = true;
            }

            if (canFire) {
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