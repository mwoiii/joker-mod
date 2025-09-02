using System;
using EntityStates;
using RoR2;


namespace JokerMod.Joker.SkillStates {
    public class SwapSlotMenu : OverrideMenu {

        public bool skillMenuWasActive;

        private int firstSelection;

        private Func<InputBankTest.ButtonState> waitForButton;

        private bool buttonStillDown = false;

        public override void OnEnter() {
            base.OnEnter();
            holdSpecialStock -= 1; // prevent opening menu for free recharge 
            EntityStateMachine.FindByCustomName(characterBody.gameObject, "Weapon").SetNextState(new LockedState());
        }

        public override void FixedUpdate() {
            base.FixedUpdate();

            if (firstSelection == 0) {
                if (base.inputBank.skill1.justPressed) {
                    Log.Info("Made first selection of skill1");
                    firstSelection = 1;
                    waitForButton = () => base.inputBank.skill1;
                    buttonStillDown = true;
                } else if (base.inputBank.skill2.justPressed) {
                    Log.Info("Made first selection of skill2");
                    firstSelection = 2;
                    waitForButton = () => base.inputBank.skill2;
                    buttonStillDown = true;
                } else if (base.inputBank.skill3.justPressed) {
                    Log.Info("Made first selection of skill3");
                    firstSelection = 3;
                    waitForButton = () => base.inputBank.skill3;
                    buttonStillDown = true;
                } else if (base.inputBank.skill4.justPressed && !base.inputBank.skill4.hasPressBeenClaimed) {
                    Log.Info("Made first selection of skill4 - attempting close");
                    CloseMenu(4);
                }

            } else if (buttonStillDown) {
                if (!waitForButton().down) {
                    Log.Info("Released the button from first selection");
                    buttonStillDown = false;
                } else if (base.inputBank.skill4.justPressed) {
                    CloseMenu(4);
                }

            } else if (firstSelection != 0) {
                if (base.inputBank.skill1.down) {
                    Log.Info("Made second selection of skill1");
                    SwapWithSlot(1);
                } else if (base.inputBank.skill2.down) {
                    Log.Info("Made second selection of skill2");
                    SwapWithSlot(2);
                } else if (base.inputBank.skill3.down) {
                    Log.Info("Made second selection of skill3");
                    SwapWithSlot(3);
                } else if (base.inputBank.skill4.down) {
                    Log.Info("Made second selection of skill4 - attemping close");
                    CloseMenu(4);
                }
            }
        }

        private void SwapWithSlot(int secondSelection) {
            master.statController.SwapPersonaSlots(firstSelection, secondSelection);
            master.statController.UpdateAndDisplaySPCosts();
            firstSelection = 0;
        }



        private void CloseMenu(int slot) {
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
