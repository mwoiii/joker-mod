using R2API;
using RoR2;

namespace JokerMod.Modules.DamageTypes {
    public static class BlessHeavyType {

        public static DamageAPI.ModdedDamageType damageType;

        public static void Init() {
            damageType = DamageAPI.ReserveDamageType();
            DamageTypeCollection.damageTypes.Add(damageType);
            Hooks.Handle_HealthComponentTakeDamageProcess_Actions += AddHeavyBlessBuffs;
        }

        private static float buffDuration = 20f;

        private static void AddHeavyBlessBuffs(HealthComponent self, DamageInfo damageInfo) {
            if (damageInfo.HasModdedDamageType(damageType)) {
                CharacterBody attackerBody = damageInfo.attacker?.GetComponent<CharacterBody>();
                if (attackerBody != null) {
                    BuffDef buffDef = (BuffDef)Utils.RandomChoice(BlessUtils.buffList);
                    attackerBody.AddTimedBuff(buffDef, buffDuration);
                }
            }
        }
    }
}
