using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class NukeHeavyWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddNukeHeavyWeakBuff;
        }

        private static void AddNukeHeavyWeakBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                for (int i = 0; i < 2; i++) {
                    DotController.InflictDot(self.body.gameObject, damageInfo.attacker, Buffs.IrradiatedDebuff.dotIndex, float.PositiveInfinity, 1f);
                }
            }
        }
    }
}