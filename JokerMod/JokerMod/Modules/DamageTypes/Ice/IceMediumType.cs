using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class IceMediumType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddIceMediumBuff;
        }

        private static void AddIceMediumBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                for (int i = 0; i < 3; i++) {
                    DotController.InflictDot(self.body.gameObject, damageInfo.attacker, DotController.DotIndex.Frost, 10f, 1f);
                }
            }
        }
    }
}