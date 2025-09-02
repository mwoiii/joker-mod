using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class CurseUtils {
        public static void TakeExtraPercentageDamage(HealthComponent self, DamageInfo damageInfo, float percent) {
            if (self != null) {
                self.TakeDamage(new DamageInfo {
                    damage = self.fullCombinedHealth * percent,
                    inflictor = damageInfo.inflictor,
                    attacker = damageInfo.attacker,
                    position = damageInfo.position,
                    procCoefficient = 0f
                });
            }
        }
    }
}
