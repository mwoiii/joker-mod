using EntityStates;
using JokerMod.Joker.Components;

namespace JokerMod.Joker.SkillStates.BaseStates {
    public abstract class PersonaSkillProjectileBaseState : GenericProjectileBaseState {

        protected JokerMaster master;

        public virtual float spCost { get; }

        protected bool canFire;

        protected abstract void ActivateSkill();

        public override void OnEnter() {

            baseDuration = 0.2f;

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
            }

            base.OnEnter();
        }

        public override void FireProjectile() {
            if (canFire) {
                base.FireProjectile();
            }
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (fixedAge >= duration && isAuthority) {
                outer.SetNextStateToMain();
                return;
            }
        }
    }
}