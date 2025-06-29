using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class NukeHeavyType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddNukeHeavyBuff;
        }

        private static void AddNukeHeavyBuff(HealthComponent self, DamageInfo damageInfo) {
            if (self.body != null && damageInfo.HasModdedDamageType(damageType)) {
                // heavy nuke is a multihit
                for (int i = 0; i < 2; i++) {
                    DotController.InflictDot(self.body.gameObject, damageInfo.attacker, Buffs.IrradiatedDebuff.dotIndex, float.PositiveInfinity, 1f);
                }
                self.body.AddTimedBuff(RoR2Content.Buffs.Weak, 12f);
            }
        }
    }
}