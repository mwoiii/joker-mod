using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class CurseLightWeakType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddLightWeakCurseDamage;
        }

        private static void AddLightWeakCurseDamage(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                if (self?.body != null) {
                    int buffCount = self.body.GetBuffCount(RoR2Content.Buffs.PermanentCurse);
                    // formula for effective multiplier: 1 / (1 + 0.01 * 11)
                    for (int i = 0; i < 3; i++) {
                        self.body.AddBuff(RoR2Content.Buffs.PermanentCurse);
                    }
                }
                CurseUtils.TakeExtraDamage(self, damageInfo, 0.03f, 2f);
            }
        }
    }
}