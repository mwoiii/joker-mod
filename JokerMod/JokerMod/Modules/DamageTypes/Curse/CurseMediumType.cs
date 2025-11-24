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
                if (self?.body != null) {
                    int buffCount = self.body.GetBuffCount(RoR2Content.Buffs.PermanentCurse);
                    for (int i = 0; i < 10; i++) {
                        self.body.AddBuff(RoR2Content.Buffs.PermanentCurse);
                    }
                }
                CurseUtils.TakeExtraDamage(self, damageInfo, 0.08f, 5f);
            }
        }
    }
}