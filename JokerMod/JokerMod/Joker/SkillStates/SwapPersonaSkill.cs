using System;
using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Skills;
using UnityEngine;


namespace JokerMod.Joker.SkillStates {
    public class SwapPersonaSkill : OverrideMenu {

        private bool skillMenuWasActive;

        public SwapPersonaSkill(bool skillMenuWasActive) {
            this.skillMenuWasActive = skillMenuWasActive;
        }

        public override void OnEnter() {
            Log.Info(skillMenuWasActive);
            base.OnEnter();
            alwaysUnsetOnExit = false;  // messy
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
            master.personaStockController.SwapPersona(slot);
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
