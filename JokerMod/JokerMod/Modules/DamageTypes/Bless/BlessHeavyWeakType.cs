﻿using JokerMod.Modules.Buffs;
using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class BlessHeavyWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddBlessHeavyWeakBuff;
        }

        private static void AddBlessHeavyWeakBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                self.body.AddTimedBuff(HallowedDebuff.buffDef, 16f);
            }
        }
    }
}