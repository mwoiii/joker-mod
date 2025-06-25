using EntityStates;
//Since we are using effects from Commando's Barrage skill, we will also be using the associated namespace
//You can also use Addressables or LegacyResourcesAPI to load whichever effects you like
using RoR2;

namespace JokerMod.Joker.SkillStates {
    public class WaitForReleaseOverrideState : OverrideMenu {

        int slot;

        public WaitForReleaseOverrideState(int slot) {
            this.slot = slot;
        }

        public override void FixedUpdate() {
            if (WaitForReleaseState.CheckSkillUpOrInterrupt(slot, base.inputBank)) {
                outer.SetNextState(new OverrideMenu());
                EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextStateToMain();
            }

            base.FixedUpdate();
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}