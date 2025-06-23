using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class CurseHeavyType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddHeavyCurseDamage;
        }

        private static void AddHeavyCurseDamage(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                damageInfo.damage += self.fullCombinedHealth * 0.12f;
                if (self.body != null) {
                    int buffCount = self.body.GetBuffCount(RoR2Content.Buffs.PermanentCurse);
                    for (int i = 0; i < 35 - buffCount; i++) {
                        self.body.AddBuff(RoR2Content.Buffs.PermanentCurse);
                    }
                }
            }
        }
    }
}