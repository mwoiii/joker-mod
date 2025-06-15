using EntityStates;
using RoR2;
using UnityEngine;
using System;
using UnityEngine.Networking;
using static EntityStates.Toolbot.ToolbotStanceBase;


namespace SkillTest.MyEntityStates {
    public class UsePersonaSkill : BaseState {

        private JokerSkillHandler skillHandler;

        private GenericSkill primary;
        private GenericSkill secondary;
        private GenericSkill utility;
        private GenericSkill special;

        private float holdSecondaryStopwatch;

        private int holdSecondaryStock;

        private float holdUtilityStopwatch;

        private int holdUtilityStock;

        public override void OnEnter() {
            base.OnEnter();

            skillHandler = base.GetComponent<JokerSkillHandler>();
            skillHandler.skillMenuActive = true;
            skillHandler.skillUsed = false;
            skillHandler.EnemySlainDuringMenu += KillInMenu;

            primary = base.skillLocator.primary;
            secondary = base.skillLocator.secondary;
            utility = base.skillLocator.utility;
            special = base.skillLocator.special;

            holdSecondaryStopwatch = secondary.rechargeStopwatch;
            holdSecondaryStock = secondary.stock;
            holdUtilityStopwatch = utility.rechargeStopwatch;
            holdUtilityStock = utility.stock;

            if (base.isAuthority && (bool)base.skillLocator) {
                primary.SetSkillOverride(base.gameObject, skillHandler.skillPrimary, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.SetSkillOverride(base.gameObject, skillHandler.skillSecondary, GenericSkill.SkillOverridePriority.Upgrade);
                utility.SetSkillOverride(base.gameObject, skillHandler.skillUtility, GenericSkill.SkillOverridePriority.Upgrade);
                special.SetSkillOverride(base.gameObject, CancelPersonaSkill.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
            }
        }

        public override void OnExit() {
            skillHandler.skillMenuActive = false;
            skillHandler.EnemySlainDuringMenu -= KillInMenu;

            if (base.isAuthority && (bool)base.skillLocator) {
                primary.UnsetSkillOverride(base.gameObject, skillHandler.skillPrimary, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.UnsetSkillOverride(base.gameObject, skillHandler.skillSecondary, GenericSkill.SkillOverridePriority.Upgrade);
                utility.UnsetSkillOverride(base.gameObject, skillHandler.skillUtility, GenericSkill.SkillOverridePriority.Upgrade);
                special.UnsetSkillOverride(base.gameObject, CancelPersonaSkill.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
            }

            secondary.rechargeStopwatch = holdSecondaryStopwatch % secondary.finalRechargeInterval; 
            secondary.stock = Math.Clamp(holdSecondaryStock + ((int)holdSecondaryStopwatch / (int)secondary.finalRechargeInterval), 0, secondary.maxStock);
            utility.rechargeStopwatch = holdUtilityStopwatch % utility.finalRechargeInterval;
            utility.stock = Math.Clamp(holdUtilityStock + ((int)holdUtilityStopwatch / (int)utility.finalRechargeInterval), 0, utility.maxStock); ;

            if (skillHandler.skillUsed) {
                special.stock -= 1;
            }

            base.OnExit();
        }

        public override void FixedUpdate() {
            base.FixedUpdate();
            holdSecondaryStopwatch += Time.fixedDeltaTime;
            holdUtilityStopwatch += Time.fixedDeltaTime;
        }

        private void KillInMenu() {
            if (skillHandler.skillMenuActive) {
                holdSecondaryStock += 1;
            }
        }
    }
}
