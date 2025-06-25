using EntityStates;
using RoR2;


namespace JokerMod.Joker.SkillStates {
    public class SwapPersonaSkill : OverrideMenu {

        private bool skillMenuWasActive;

        public SwapPersonaSkill(bool skillMenuWasActive) {
            this.skillMenuWasActive = skillMenuWasActive;
        }

        public override void OnEnter() {
            base.OnEnter();
            holdSpecialStock -= 1; // prevent opening menu for free recharge 
            EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(new LockedState());
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (base.inputBank.skill1.down) {
                SwapAndWaitRelease(1);
            } else if (base.inputBank.skill2.down) {
                SwapAndWaitRelease(2);
            } else if (base.inputBank.skill3.down) {
                SwapAndWaitRelease(3);
            } else if (base.inputBank.skill4.down) {
                SwapAndWaitRelease(4);
            }
        }

        private void SwapAndWaitRelease(int slot) {
            master.statController.SwapPersona(slot);
            if (skillMenuWasActive) {
                outer.SetNextState(new WaitForReleaseOverrideState(slot));
            } else {
                outer.SetNextState(new WaitForReleaseState(slot));
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}
