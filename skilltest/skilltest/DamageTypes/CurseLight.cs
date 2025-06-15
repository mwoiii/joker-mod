using System;
using System.Collections.Generic;
using System.Text;
using R2API;
using RoR2;

namespace SkillTest.DamageTypes
{
    public static class CurseLight {

        public static DamageAPI.ModdedDamageType damageType;

        static CurseLight() {
            damageType = DamageAPI.ReserveDamageType();
            On.RoR2.HealthComponent.TakeDamageProcess += AddLightPercentageDamage;
        }

        private static void AddLightPercentageDamage(On.RoR2.HealthComponent.orig_TakeDamageProcess orig, RoR2.HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                damageInfo.damage += self.fullCombinedHealth * 0.05f;
            }
            orig(self, damageInfo);
        }
    }
}
