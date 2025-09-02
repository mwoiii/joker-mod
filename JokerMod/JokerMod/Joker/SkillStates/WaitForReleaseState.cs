using EntityStates;
//Since we are using effects from Commando's Barrage skill, we will also be using the associated namespace
//You can also use Addressables or LegacyResourcesAPI to load whichever effects you like
using RoR2;

namespace JokerMod.Joker.SkillStates {
    public class WaitForReleaseState : BaseState {

        public int slot;

        public override void FixedUpdate() {
            if (WaitForReleaseState.CheckSkillUpOrInterrupt(slot, base.inputBank)) {
                outer.SetNextStateToMain();
                EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextStateToMain();
            }

            base.FixedUpdate();
        }

        public static bool CheckSkillUpOrInterrupt(int slot, InputBankTest inputBank) {
            switch (slot) {
                case 1:
                    if (!inputBank.skill1.down || inputBank.skill2.down || inputBank.skill3.down || inputBank.skill4.down) {
                        return true;
                    }
                    break;

                case 2:
                    if (inputBank.skill1.down || !inputBank.skill2.down || inputBank.skill3.down || inputBank.skill4.down) {
                        return true;
                    }
                    break;

                case 3:
                    if (inputBank.skill1.down || inputBank.skill2.down || !inputBank.skill3.down || inputBank.skill4.down) {
                        return true;
                    }
                    break;

                case 4:
                    if (inputBank.skill1.down || inputBank.skill2.down || inputBank.skill3.down || !inputBank.skill4.down) {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public override InterruptPriority GetMinimumInterruptPriority() {
            return InterruptPriority.Death;
        }
    }
}