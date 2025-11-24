using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class IceLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddIceLightBuff;
        }

        private static void AddIceLightBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self?.body != null && damageInfo.HasModdedDamageType(damageType)) {
                for (int i = 0; i < 2; i++) {
                    DotController.InflictDot(self.body.gameObject, damageInfo.attacker, DotController.DotIndex.Frost, 8f, 1f, null);
                }
            }
        }
    }
}