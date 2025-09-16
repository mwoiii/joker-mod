using System;
using EntityStates;
using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates.PersonaStates;
using JokerMod.Modules;
using RoR2;
using RoR2.Audio;
using RoR2.Skills;
using UnityEngine;
using UnityEngine.Networking;


namespace JokerMod.Joker.SkillStates {
    public class OverrideMenu : BaseSkillState {

        protected JokerMaster jokerMaster;

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

        protected bool shouldPlaySFX;

        public override void OnEnter() {
            base.OnEnter();

            jokerMaster = GetComponent<JokerMaster>();
            jokerMaster.statController.UpdateAndDisplaySPCosts();
            jokerMaster.skillMenuActive = true;
            jokerMaster.skillUsed = false;
            jokerMaster.EnemySlainDuringMenu += KillInMenu;

            if (shouldPlaySFX && NetworkServer.active) {
                jokerMaster.voiceController.TryPlayRandomNetworkedSound(JokerAssets.summonPersonaSoundEvents, characterBody.gameObject, true);
            }

            if (shouldPlaySFX && isAuthority) {
                EntitySoundManager.EmitSoundLocal(JokerAssets.unleashSoundEvent.akId, characterBody.gameObject);
            }

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
                primary.SetSkillOverride(gameObject, jokerMaster.statController.primaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.SetSkillOverride(gameObject, jokerMaster.statController.secondaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                utility.SetSkillOverride(gameObject, jokerMaster.statController.utilityPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                special.SetSkillOverride(gameObject, cancelSkill, GenericSkill.SkillOverridePriority.Upgrade);
            }
        }

        public override void OnExit() {
            jokerMaster.skillMenuActive = false;
            jokerMaster.statController.HideSPCosts();
            jokerMaster.EnemySlainDuringMenu -= KillInMenu;

            if (isAuthority && skillLocator != null) {
                primary.UnsetSkillOverride(gameObject, jokerMaster.statController.primaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                secondary.UnsetSkillOverride(gameObject, jokerMaster.statController.secondaryPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                utility.UnsetSkillOverride(gameObject, jokerMaster.statController.utilityPersona.skillDef, GenericSkill.SkillOverridePriority.Upgrade);
                special.UnsetSkillOverride(gameObject, cancelSkill, GenericSkill.SkillOverridePriority.Upgrade);
            }

            secondary.rechargeStopwatch = holdSecondaryStopwatch % secondary.finalRechargeInterval;
            secondary.stock = Math.Clamp(holdSecondaryStock + (int)(holdSecondaryStopwatch / secondary.finalRechargeInterval), 0, secondary.maxStock);
            utility.rechargeStopwatch = holdUtilityStopwatch % utility.finalRechargeInterval;
            utility.stock = Math.Clamp(holdUtilityStock + (int)(holdUtilityStopwatch / utility.finalRechargeInterval), 0, utility.maxStock);
            special.stock = Math.Clamp(holdSpecialStock + (int)(holdSpecialStopwatch / special.finalRechargeInterval), 0, special.maxStock);

            if (jokerMaster.skillUsed) {
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
            if (jokerMaster.skillMenuActive) {
                holdSecondaryStock += 1;
            }
        }
    }
}
