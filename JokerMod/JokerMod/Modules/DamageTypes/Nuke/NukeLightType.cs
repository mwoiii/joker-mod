using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class NukeLightType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddNukeLightBuff;
        }

        private static void AddNukeLightBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self?.body != null && damageInfo.HasModdedDamageType(damageType)) {
                for (int i = 0; i < 4; i++) {
                    DotController.InflictDot(self.body.gameObject, damageInfo.attacker, Buffs.IrradiatedDebuff.dotIndex, float.PositiveInfinity, 1f, null);
                }
                self.body.AddTimedBuff(RoR2Content.Buffs.Weak, 5f);
            }
        }
    }
}