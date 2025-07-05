using JokerMod.Joker.SkillStates.BaseStates;

namespace JokerMod.Joker.SkillStates {
    public class ChargeSpecial : OverrideMenu {

        public const float SWAP_THRESHOLD = 1f;

        public override void OnEnter() {
            base.OnEnter();
            ChargeBase.ApplyRecharge(skillLocator.special);
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (!isAuthority) {
                return;
            }

            if (IsKeyDownAuthority() && fixedAge >= SWAP_THRESHOLD) {
                SwapSlotMenu nextState = new SwapSlotMenu(false);
                Log.Info("Setting charge state to SwapSlotMenu");
                base.inputBank.skill4.hasPressBeenClaimed = true;
                outer.SetNextState(nextState);
            } else if (!IsKeyDownAuthority()) {
                OverrideMenu nextState = new OverrideMenu();
                Log.Info("Setting charge state to OverrideMenu");
                outer.SetNextState(nextState);
                // EntityStateMachine.FindByCustomName(characterBody.gameObject, "Charge").SetNextState(nextState);
            }
        }
    }
}