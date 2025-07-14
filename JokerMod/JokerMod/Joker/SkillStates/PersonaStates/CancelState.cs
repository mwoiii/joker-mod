namespace JokerMod.Joker.SkillStates.PersonaStates {
    public class CancelState : OverrideMenu {

        public override void FixedUpdate() {
            base.FixedUpdate();
            if (!isAuthority) {
                return;
            }

            if (IsKeyDownAuthority() && fixedAge >= ChargeSpecial.SWAP_THRESHOLD) {
                SwapSlotMenu nextState = new SwapSlotMenu(true);
                base.inputBank.skill4.hasPressBeenClaimed = true;
                outer.SetNextState(nextState);
            } else if (!IsKeyDownAuthority()) {
                outer.SetNextStateToMain();
            }
        }
    }
}
