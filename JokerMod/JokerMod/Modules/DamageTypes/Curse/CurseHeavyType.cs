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
                if (self?.body != null) {
                    int buffCount = self.body.GetBuffCount(RoR2Content.Buffs.PermanentCurse);
                    for (int i = 0; i < 20; i++) {
                        self.body.AddBuff(RoR2Content.Buffs.PermanentCurse);
                    }
                }
                CurseUtils.TakeExtraDamage(self, damageInfo, 0.12f, 8f);
            }
        }
    }
}