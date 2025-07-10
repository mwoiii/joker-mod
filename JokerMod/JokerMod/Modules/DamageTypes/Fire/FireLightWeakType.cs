using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class FireLightWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddFireLightWeakBuff;
        }

        private static void AddFireLightWeakBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                DotController.InflictDot(self.body.gameObject, damageInfo.attacker, DotController.DotIndex.Burn, 8f, 1f);
            }
        }
    }
}