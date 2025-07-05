using System;
using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Skills;
using UnityEngine;


namespace JokerMod.Joker.SkillStates {
    public class OverrideMenu : BaseSkillState {

        protected JokerMaster master;

        protected GenericSkill primary;
        protected GenericSkill secondary;
        protected GenericSkill utility;
        protected GenericSkill special;

        protected static SkillDef cancelSkill = JokerCatalog.GetSkillDefFromType(typeof(CancelState));

        protected float holdSecondaryStopwatch;

        protected int holdSecondaryStock;

        protected float holdUtilityStopwatch;

        protected int holdUtilityStock;

        protected float holdSpecialStopwatch;

        protected int holdSpecialStock;

        public override void OnEnter() {
            base.OnEnter();

            master = GetComponent<JokerMaster>();
            master.statController.UpdateAndDisplaySPCosts();
            master.skillMenuActive = true;
            master.skillUsed = false;
            master.EnemySlainDuringMenu += KillInMenu;

            primary = skillLocator.primary;
            secondary = skillLocator.secondary;
            utility = skillLocator.utility;
            special = skillLocator.special;

            holdSecondaryStopwatch = secondary.rechargeStopwatch;
            holdSecondaryStock = secondary.stock;
            holdUtilityStopwatch = utility.rechargeStopwatch;
            holdUtilityStock = utility.stock;
            holdSpecialStopwatch = special.rechargeStopwatch;
            holdSpecialStock = special.stock + 1; // only go on cooldown if skill used

            if (isAuthority && (bool)skillLocator) {
                primary.SetSkillOverride(gameObject, master.statController.primaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.SetSkillOverride(gameObject, master.statController.secondaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                utility.SetSkillOverride(gameObject, master.statController.utilityPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                special.SetSkillOverride(gameObject, cancelSkill, GenericSkill.SkillOverridePriority.Upgrade);
            }
        }

        public override void OnExit() {
            master.skillMenuActive = false;
            master.statController.HideSPCosts();
            master.EnemySlainDuringMenu -= KillInMenu;

            if (isAuthority && skillLocator != null) {
                primary.UnsetSkillOverride(gameObject, master.statController.primaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.UnsetSkillOverride(gameObject, master.statController.secondaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                utility.UnsetSkillOverride(gameObject, master.statController.utilityPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                special.UnsetSkillOverride(gameObject, cancelSkill, GenericSkill.SkillOverridePriority.Upgrade);
            }

            secondary.rechargeStopwatch = holdSecondaryStopwatch % secondary.finalRechargeInterval;
            secondary.stock = Math.Clamp(holdSecondaryStock + (int)(holdSecondaryStopwatch / secondary.finalRechargeInterval), 0, secondary.maxStock);
            utility.rechargeStopwatch = holdUtilityStopwatch % utility.finalRechargeInterval;
            utility.stock = Math.Clamp(holdUtilityStock + (int)(holdUtilityStopwatch / utility.finalRechargeInterval), 0, utility.maxStock);
            special.stock = Math.Clamp(holdSpecialStock + (int)(holdSpecialStopwatch / special.finalRechargeInterval), 0, special.maxStock);

            if (master.skillUsed) {
                special.stock -= 1;
            } else {
                special.rechargeStopwatch = holdSpecialStopwatch % special.finalRechargeInterval;
            }

            base.OnExit();
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            holdSecondaryStopwatch += Time.fixedDeltaTime;
            holdUtilityStopwatch += Time.fixedDeltaTime;
            holdSpecialStopwatch += Time.fixedDeltaTime;
        }

        private void KillInMenu() {
            if (master.skillMenuActive) {
                holdSecondaryStock += 1;
            }
        }
    }
}
