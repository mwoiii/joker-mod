using System;
using System.Collections.Generic;
using System.Text;
using static MonoMod.InlineRT.MonoModRule;
using Mono.Cecil.Cil;
using UnityEngine;
using MonoMod.Cil;
using System.Diagnostics;
using System.Reflection;
using UnityEngine.UIElements;

namespace SkillTest {
    public static class Hooks {

        public delegate void Handle_CharacterBodyOnLevelUp(RoR2.CharacterBody self);
        public static Handle_CharacterBodyOnLevelUp Handle_CharacterBodyOnLevelUp_Actions;

        public delegate void Handle_SkillIconUpdate(RoR2.UI.SkillIcon self);
        public static Handle_SkillIconUpdate Handle_SkillIconUpdate_Actions;

        public static void AddHooks() {
            SPController.SubscribeStaticHooksAndEvents();

            Handle_SkillIconUpdate_Actions += FixSkillCooldownDisplay;

            if (Handle_CharacterBodyOnLevelUp_Actions != null) {
                On.RoR2.CharacterBody.OnLevelUp += CharacterBody_OnLevelUp;
            }

            if (Handle_SkillIconUpdate_Actions != null) {
                On.RoR2.UI.SkillIcon.Update += SkillIcon_Update;
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
