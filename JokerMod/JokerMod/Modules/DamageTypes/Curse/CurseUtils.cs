using RoR2;
using UnityEngine;

namespace JokerMod.Modules.DamageTypes {
    public static class CurseUtils {
        public static void TakeExtraDamage(HealthComponent self, DamageInfo damageInfo, float percent, float damageMult = 3f) {
            if (self != null) {
                float minDamage = damageInfo?.attacker?.GetComponent<CharacterBody>() ? damageInfo.attacker.GetComponent<CharacterBody>().damage * damageMult : 0f;
                self.TakeDamage(new DamageInfo {
                    damage = Mathf.Max(self.fullCombinedHealth * percent, minDamage),
                    inflictor = damageInfo.inflictor,
                    attacker = damageInfo.attacker,
                    position = damageInfo.position,
                    procCoefficient = 0f
                });
            }
        }
    }
}
