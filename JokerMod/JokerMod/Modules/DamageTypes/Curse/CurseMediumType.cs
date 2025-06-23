using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class CurseMediumType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddMediumCurseDamage;
        }

        private static void AddMediumCurseDamage(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                damageInfo.damage += self.fullCombinedHealth * 0.08f;
                if (self.body != null) {
                    int buffCount = self.body.GetBuffCount(RoR2Content.Buffs.PermanentCurse);
                    for (int i = 0; i < 20 - buffCount; i++) {
                        self.body.AddBuff(RoR2Content.Buffs.PermanentCurse);
                    }
                }
            }
        }
    }
}