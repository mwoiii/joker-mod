using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class NukeLightWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddNukeLightWeakBuff;
        }

        private static void AddNukeLightWeakBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                DotController.InflictDot(self.body.gameObject, damageInfo.attacker, Buffs.IrradiatedDebuff.dotIndex, float.PositiveInfinity, 1f);
            }
        }
    }
}