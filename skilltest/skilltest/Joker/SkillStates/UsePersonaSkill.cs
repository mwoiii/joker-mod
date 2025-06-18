using EntityStates;
using RoR2;
using UnityEngine;
using System;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;


namespace JokerMod.Joker.SkillStates
{
    public class UsePersonaSkill : BaseState
    {

        private JokerMaster master;

        private GenericSkill primary;
        private GenericSkill secondary;
        private GenericSkill utility;
        private GenericSkill special;

        private float holdSecondaryStopwatch;

        private int holdSecondaryStock;

        private float holdUtilityStopwatch;

        private int holdUtilityStock;

        private float holdSpecialStopwatch;

        private int holdSpecialStock;

        public override void OnEnter()
        {
            base.OnEnter();

            master = GetComponent<JokerMaster>();
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

            if (isAuthority && (bool)skillLocator)
            {
                primary.SetSkillOverride(gameObject, master.skillPrimary, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.SetSkillOverride(gameObject, master.skillSecondary, GenericSkill.SkillOverridePriority.Upgrade);
                utility.SetSkillOverride(gameObject, master.skillUtility, GenericSkill.SkillOverridePriority.Upgrade);
                special.SetSkillOverride(gameObject, JokerCatalog.GetSkillDefFromType(typeof(CancelState)), GenericSkill.SkillOverridePriority.Upgrade);
            }
        }

        public override void OnExit()
        {
            master.skillMenuActive = false;
            master.EnemySlainDuringMenu -= KillInMenu;

            if (isAuthority && (bool)skillLocator)
            {
                primary.UnsetSkillOverride(gameObject, master.skillPrimary, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.UnsetSkillOverride(gameObject, master.skillSecondary, GenericSkill.SkillOverridePriority.Upgrade);
                utility.UnsetSkillOverride(gameObject, master.skillUtility, GenericSkill.SkillOverridePriority.Upgrade);
                special.UnsetSkillOverride(gameObject, JokerCatalog.GetSkillDefFromType(typeof(CancelState)), GenericSkill.SkillOverridePriority.Upgrade);
            }

            secondary.rechargeStopwatch = holdSecondaryStopwatch % secondary.finalRechargeInterval;
            secondary.stock = Math.Clamp(holdSecondaryStock + (int)(holdSecondaryStopwatch / secondary.finalRechargeInterval), 0, secondary.maxStock);
            utility.rechargeStopwatch = holdUtilityStopwatch % utility.finalRechargeInterval;
            utility.stock = Math.Clamp(holdUtilityStock + (int)(holdUtilityStopwatch / utility.finalRechargeInterval), 0, utility.maxStock); ;
            special.rechargeStopwatch = holdSpecialStopwatch % special.finalRechargeInterval;
            special.stock = Math.Clamp(holdSpecialStock + (int)(holdSpecialStopwatch / special.finalRechargeInterval), 0, special.maxStock);

            if (master.skillUsed)
            {
                special.stock -= 1;
            }

            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            holdSecondaryStopwatch += Time.fixedDeltaTime;
            holdUtilityStopwatch += Time.fixedDeltaTime;
            holdSpecialStopwatch += Time.fixedDeltaTime;
        }

        private void KillInMenu()
        {
            if (master.skillMenuActive)
            {
                holdSecondaryStock += 1;
            }
        }
    }
}
