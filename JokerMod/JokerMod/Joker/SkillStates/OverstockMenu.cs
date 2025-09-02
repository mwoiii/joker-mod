using EntityStates;
using RoR2;


namespace JokerMod.Joker.SkillStates {
    public class OverstockMenu : OverrideMenu {

        public bool skillMenuWasActive;

        public override void OnEnter() {
            base.OnEnter();
            holdSpecialStock -= 1; // prevent opening menu for free recharge 
            EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(new LockedState());
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (isAuthority) {
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
        }

        private void SwapAndWaitRelease(int slot) {
            master.statController.SwapPersonaWithOverstock(slot);
            if (skillMenuWasActive) {
                WaitForReleaseOverrideState nextState = new WaitForReleaseOverrideState();
                nextState.slot = slot;
                outer.SetNextState(nextState);
            } else {
                WaitForReleaseState nextState = new WaitForReleaseState();
                nextState.slot = slot;
                outer.SetNextState(nextState);
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}
