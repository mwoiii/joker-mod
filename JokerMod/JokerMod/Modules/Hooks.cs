using JokerMod.Joker.Components;
using JokerMod.Joker.SkillStates;
using MonoMod.Cil;

namespace JokerMod.Modules {
    public static class Hooks {

        public delegate void Handle_CharacterBodyOnLevelUp(RoR2.CharacterBody self);
        public static Handle_CharacterBodyOnLevelUp Handle_CharacterBodyOnLevelUp_Actions;

        public delegate void Handle_SkillIconUpdate(RoR2.UI.SkillIcon self);
        public static Handle_SkillIconUpdate Handle_SkillIconUpdate_Actions;

        public delegate void Handle_GenericPickupControllerStart(RoR2.GenericPickupController self);
        public static Handle_GenericPickupControllerStart Handle_GenericPickupControllerStart_Actions;

        public delegate void Handle_HealthComponentTakeDamageProcess(RoR2.HealthComponent self, RoR2.DamageInfo damageInfo);
        public static Handle_HealthComponentTakeDamageProcess Handle_HealthComponentTakeDamageProcess_Actions;

        public delegate void Handle_HealthComponentTakeDamageForceDamageInfoBoolBool(On.RoR2.HealthComponent.orig_TakeDamageForce_DamageInfo_bool_bool orig, RoR2.HealthComponent self, RoR2.DamageInfo damageInfo, bool alwaysApply, bool disableAirControlUntilCollision);
        public static Handle_HealthComponentTakeDamageForceDamageInfoBoolBool Handle_HealthComponentTakeDamageForceDamageInfoBoolBool_Actions;

        public delegate void Handle_CharacterMotorOnLanded(RoR2.CharacterMotor self);
        public static Handle_CharacterMotorOnLanded Handle_CharacterMotorOnLanded_Actions;

        public delegate void IL_Handle_GenericPickupControllerAttemptGrant(ILContext il);
        public static IL_Handle_GenericPickupControllerAttemptGrant IL_Handle_GenericPickupControllerAttemptGrant_Actions;

        public delegate void IL_Handle_OverlapAttackFire(ILContext il);
        public static IL_Handle_OverlapAttackFire IL_Handle_OverlapAttackFire_Actions;

        public delegate void IL_Handle_DotControllerEvaluateDOTStacksForType(ILContext il);
        public static IL_Handle_DotControllerEvaluateDOTStacksForType IL_Handle_DotControllerEvaluateDOTStacksForType_Actions;

        public delegate void IL_Handle_EquipmentSlotExecute(ILContext il);
        public static IL_Handle_EquipmentSlotExecute IL_Handle_EquipmentSlotExecute_Actions;

        public static void AddHooks() {
            SPController.SubscribeStaticHooksAndEvents();

            Handle_SkillIconUpdate_Actions += FixSkillCooldownDisplay;
            IL_Handle_EquipmentSlotExecute_Actions += SlashFlurry.RejectEquipmentExecution;

            if (Handle_CharacterBodyOnLevelUp_Actions != null) {
                On.RoR2.CharacterBody.OnLevelUp += CharacterBody_OnLevelUp;
            }

            if (Handle_SkillIconUpdate_Actions != null) {
                On.RoR2.UI.SkillIcon.Update += SkillIcon_Update;
            }

            if (Handle_GenericPickupControllerStart_Actions != null) {
                On.RoR2.GenericPickupController.Start += GenericPickupController_Start;
            }

            if (Handle_HealthComponentTakeDamageProcess_Actions != null) {
                On.RoR2.HealthComponent.TakeDamageProcess += HealthComponent_TakeDamageProcess;
            }

            if (Handle_HealthComponentTakeDamageProcess_Actions != null) {
                On.RoR2.HealthComponent.TakeDamageForce_DamageInfo_bool_bool += HealthComponent_TakeDamageForceDamageInfoBoolBool;
            }

            if (Handle_CharacterMotorOnLanded_Actions != null) {
                On.RoR2.CharacterMotor.OnLanded += CharacterMotor_OnLanded;
            }

            if (IL_Handle_GenericPickupControllerAttemptGrant_Actions != null) {
                IL.RoR2.GenericPickupController.AttemptGrant += IL_GenericPickupController_AttemptGrant;
            }

            if (IL_Handle_OverlapAttackFire_Actions != null) {
                IL.RoR2.OverlapAttack.Fire += IL_OverlapAttack_Fire;
            }

            if (IL_Handle_DotControllerEvaluateDOTStacksForType_Actions != null) {
                IL.RoR2.DotController.EvaluateDotStacksForType += IL_DotController_EvaluateDOTStacksForType;
            }

            if (IL_Handle_EquipmentSlotExecute_Actions != null) {
                IL.RoR2.EquipmentSlot.Execute += IL_EquipmentSlot_Execute;
            }
        }

        internal static void CharacterBody_OnLevelUp(On.RoR2.CharacterBody.orig_OnLevelUp orig, RoR2.CharacterBody self) {
            Handle_CharacterBodyOnLevelUp_Actions.Invoke(self);
            orig(self);
        }

        internal static void SkillIcon_Update(On.RoR2.UI.SkillIcon.orig_Update orig, RoR2.UI.SkillIcon self) {
            Handle_SkillIconUpdate_Actions.Invoke(self);
            orig(self);
        }

        internal static void GenericPickupController_Start(On.RoR2.GenericPickupController.orig_Start orig, RoR2.GenericPickupController self) {
            Handle_GenericPickupControllerStart_Actions.Invoke(self);
            orig(self);
        }

        internal static void HealthComponent_TakeDamageProcess(On.RoR2.HealthComponent.orig_TakeDamageProcess orig, RoR2.HealthComponent self, RoR2.DamageInfo damageInfo) {
            Handle_HealthComponentTakeDamageProcess_Actions.Invoke(self, damageInfo);
            orig(self, damageInfo);
        }

        internal static void HealthComponent_TakeDamageForceDamageInfoBoolBool(On.RoR2.HealthComponent.orig_TakeDamageForce_DamageInfo_bool_bool orig, RoR2.HealthComponent self, RoR2.DamageInfo damageInfo, bool alwaysApply, bool disableAirControlUntilCollision) {
            Handle_HealthComponentTakeDamageForceDamageInfoBoolBool_Actions.Invoke(orig, self, damageInfo, alwaysApply, disableAirControlUntilCollision);
            // must call orig themselves
        }

        internal static void CharacterMotor_OnLanded(On.RoR2.CharacterMotor.orig_OnLanded orig, RoR2.CharacterMotor self) {
            Handle_CharacterMotorOnLanded_Actions.Invoke(self);
            orig(self);
        }

        internal static void IL_GenericPickupController_AttemptGrant(ILContext il) {
            IL_Handle_GenericPickupControllerAttemptGrant_Actions.Invoke(il);
        }

        internal static void IL_OverlapAttack_Fire(ILContext il) {
            IL_Handle_OverlapAttackFire_Actions.Invoke(il);
        }
        internal static void IL_DotController_EvaluateDOTStacksForType(ILContext il) {
            IL_Handle_DotControllerEvaluateDOTStacksForType_Actions.Invoke(il);
        }
        internal static void IL_EquipmentSlot_Execute(ILContext il) {
            IL_Handle_EquipmentSlotExecute_Actions.Invoke(il);
        }

        private static void FixSkillCooldownDisplay(RoR2.UI.SkillIcon self) {
            if ((bool)self.targetSkill && (bool)self.cooldownText) {
                float cooldownRemaining = self.targetSkill.cooldownRemaining;
                int stock = self.targetSkill.stock;
                bool flag = stock > 0 || cooldownRemaining == 0f;
                bool flag2 = self.targetSkill.IsReady();
                bool isCooldownBlocked = self.targetSkill.isCooldownBlocked;
                if (!(flag || flag2 || isCooldownBlocked)) {
                    self.cooldownText.gameObject.SetActive(value: true);
                }
            }
        }
    }
}
